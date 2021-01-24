                var entityType = Assembly.GetAssembly(typeof(BaseTypeEntity)).GetType(namespacePrefix + typeName);
                // create an instance of that type
                object instance = Activator.CreateInstance(entityType);
                // Get a property on the type that is stored in the 
                // property string
                PropertyInfo prop = entityType.GetProperty("Active");
                prop.SetValue(instance, true, null);
                // .... more properties
               
                _context.Add(instance);
