        public static Type GetActualBaseType(this object obj)
        {
            Type type = obj.GetType();
            while (type.IsNested)
                type = type.BaseType;
            return type;
        }
