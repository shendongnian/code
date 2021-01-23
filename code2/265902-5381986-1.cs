        private void recurseAndPrintProperties(Object ObjectToRecurse) {
            foreach (PropertyInfo pi in ObjectToRecurse.GetType().GetProperties()) {
                if ((pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(EntityCollection<>))) {
                    Type genericType = pi.PropertyType.GetGenericTypeDefinition();
                    Type typeArgument = genericType.GetGenericArguments()[0];
                    Type properType = genericType.MakeGenericType(typeArgument);
                    object collection = pi.GetValue(ObjectToRecurse, null);
                    for (int i = 0; i < (int)properType.GetProperties().Single(p_coll => p_coll.Name == "Count").GetValue(collection, null); i++)
                        recurseAndPrintProperties(pi.GetValue(collection, new object[] { i }));
                } else
                    Console.WriteLine(pi.GetValue(ObjectToRecurse, null));
            }
        }
