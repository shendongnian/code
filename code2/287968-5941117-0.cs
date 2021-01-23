        private class Generic<T> { 
            public void Method() { }
            public void Method(string param) { }
            public void OtherMethod() { }  
        }
        private class NonGeneric { public void Method() { } }
        static void Main(string[] args)
        {
            var x = typeof(Generic<int>).GetMethod("Method", new Type[]{});
            var y = typeof(Generic<double>).GetMethod("Method", new Type[]{});
            var a = typeof(Generic<double>).GetMethod("OtherMethod");
            var b = typeof(NonGeneric).GetMethod("Method");
            var c = typeof(Generic<int>).GetMethod("Method", new Type[] { typeof(string) });
            Debug.Assert(DeclaredInSameClass(x, y));
            Debug.Assert(!DeclaredInSameClass(x, a));
            Debug.Assert(!DeclaredInSameClass(x, b));
            Debug.Assert(!DeclaredInSameClass(x, c));
            Debug.Assert(!DeclaredInSameClass(a, b));
        }
        public static bool DeclaredInSameClass(MethodInfo a, MethodInfo b)
        {
            if (a.DeclaringType.IsGenericType != b.DeclaringType.IsGenericType)
            {
                return false;
            }
            else if (a.DeclaringType.IsGenericType)
            {
                var x = a.DeclaringType.GetGenericTypeDefinition().GetMethod(a.Name, a.GetParameters().Select(p => p.ParameterType).ToArray());
                var y = b.DeclaringType.GetGenericTypeDefinition().GetMethod(b.Name, b.GetParameters().Select(p => p.ParameterType).ToArray());
                return x.Equals(y);
            }
            return a.GetBaseDefinition().Equals(b.GetBaseDefinition());
        }
