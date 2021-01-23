        static IEnumerable<TypeUsage> SearchMessages(TypeDefinition uiType, bool onlyConstructions)
        {
            return uiType.SearchCallTree(IsBusinessCall,
                   (instruction, stack) => DetectTypeUsage(instruction, stack, onlyConstructions));
        }
        internal class TypeUsage : IEquatable<TypeUsage>
        {
            public TypeReference Type;
            public Stack<MethodReference> Stack;
            #region equality
            // ... omitted for brevity ...
            #endregion
        }
        private static TypeUsage DetectTypeUsage(
            Instruction instruction, IEnumerable<MethodReference> stack, bool onlyConstructions)
        {
            TypeDefinition resolve = null;
            {
                TypeReference tr = null;
                var methodReference = instruction.Operand as MethodReference;
                if (methodReference != null)
                    tr = methodReference.DeclaringType;
                tr = tr ?? instruction.Operand as TypeReference;
                if ((tr == null) || !IsInterestingType(tr))
                    return null;
                resolve = tr.GetOriginalType().TryResolve();
            }
            if (resolve == null)
                throw new ApplicationException("Required assembly not loaded.");
            if (resolve.IsSerializable)
                if (!onlyConstructions || IsConstructorCall(instruction))
                    return new TypeUsage {Stack = new Stack<MethodReference>(stack.Reverse()), Type = resolve};
            return null;
        }
		
