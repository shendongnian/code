        public static bool Overrides(this MethodDefinition method, MethodReference overridden)
        {
            Contract.Requires(method != null);
            Contract.Requires(overridden != null);
            bool explicitIfaceImplementation = method.Overrides.Any(overrides => overrides.IsEqual(overridden));
            if (explicitIfaceImplementation)
            {
                return true;
            }
            if (IsImplicitInterfaceImplementation(method, overridden))
            {
                return true;
            }
            // new slot method cannot override any base classes' method by convention:
            if (method.IsNewSlot)
            {
                return false;
            }
            // check base-type overrides using Cecil's helper method GetOriginalBaseMethod()
            return method.GetOriginalBaseMethod().IsEqual(overridden);
        }
        /// <summary>
        /// Implicit interface implementations are based only on method's name and signature equivalence.
        /// </summary>
        private static bool IsImplicitInterfaceImplementation(MethodDefinition method, MethodReference overridden)
        {
            // check that the 'overridden' method is iface method and the iface is implemented by method.DeclaringType
            if (overridden.DeclaringType.SafeResolve().IsInterface == false ||
                method.DeclaringType.Interfaces.None(i => i.IsEqual(overridden.DeclaringType)))
            {
                return false;
            }
            // check whether the type contains some other explicit implementation of the method
            if (method.DeclaringType.Methods.SelectMany(m => m.Overrides).Any(m => m.IsEqual(overridden)))
            {
                // explicit implementation -> no implicit implementation possible
                return false;
            }
            // now it is enough to just match the signatures and names:
            return method.Name == overridden.Name && method.SignatureMatches(overridden);
        }
        static bool IsEqual(this MethodReference method1, MethodReference method2)
        {
            return method1.Name == method2.Name &&  method1.DeclaringType.IsEqual(method2.DeclaringType);
        }
        // IsEqual for TypeReference is similar...
