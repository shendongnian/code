        public static object GetDefaultValue(Type type)
        {
            if (type.IsValueType)
            {
                ConstructorInfo ctor = type.GetConstructor(new Type[0]);
                return ctor.Invoke(new object[0]);
            }
            else
            {
                return null;
            }
        }
