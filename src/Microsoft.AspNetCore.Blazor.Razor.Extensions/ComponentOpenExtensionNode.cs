﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using Microsoft.AspNetCore.Razor.Language.Intermediate;

namespace Microsoft.AspNetCore.Blazor.Razor
{
    internal class ComponentOpenExtensionNode : ExtensionIntermediateNode
    {
        public override IntermediateNodeCollection Children => IntermediateNodeCollection.ReadOnly;

        public string TypeName { get; set; }

        public override void Accept(IntermediateNodeVisitor visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }

            AcceptExtensionNode<ComponentOpenExtensionNode>(this, visitor);
        }

        public override void WriteNode(CodeTarget target, CodeRenderingContext context)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var writer = (BlazorNodeWriter)context.NodeWriter;
            writer.WriteComponentOpen(context, this);
        }
    }
}
