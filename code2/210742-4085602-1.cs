    public static object CloneProperties(object o)
            {
                var type = o.GetType();
                var clone = Activator.CreateInstance(type);
                foreach (var property in type.GetProperties())
                {
                    if (property.GetSetMethod() != null && property.GetValue(o, null) != null)
                        property.SetValue(clone, property.GetValue(o, null), null);
                }
                return clone;
            }
