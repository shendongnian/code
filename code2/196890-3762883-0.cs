        static void GetProperties(Type type)
        {
            if (type.BaseType != null)
            {
                GetProperties(type.BaseType);
            }
            foreach (var item in type.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public))
            {
                MethodInfo method = item.GetGetMethod();
                MethodInfo baseMethod = method.GetBaseDefinition();
                System.Diagnostics.Debug.WriteLine(string.Format("{0} {1}.{2} {3}.{4}", type.Name, method.DeclaringType.Name, method.Name, baseMethod.DeclaringType, baseMethod.Name));
                if (baseMethod.DeclaringType == type)
                {
                    Console.WriteLine("{0} {1}", type.Name, item.Name);
                }
            }
        }
