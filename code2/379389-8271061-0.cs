            foreach (PropertyInfo pi in container.GetType().GetProperties())
            {
                    Type generic = typeof(GenericObject<>);
                    Type[] typeArgs = { pi.PropertyType};
                    Type constructed = generic.MakeGenericType(typeArgs);
                    object[] args = new object[] { container, pi.Name };
                    var p = Activator.CreateInstance(constructed, args);
            }
