        public static List<Type> BuiltInTypes
            {
                get
                {
                    if (builtInTypes == null)                
                        builtInTypes = Enum.GetValues(typeof(TypeCode)).Cast<TypeCode>().Select(t => Type.GetType("System." + Enum.GetName(typeof(TypeCode), t)))
                                       .ToList();
        
                    return builtInTypes;
                }
            }
