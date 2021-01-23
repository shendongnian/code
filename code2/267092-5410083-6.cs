        public static bool IsNullableType(this Type type)
        {
            return 
                (type.IsGenericType && !type.IsGenericTypeDefinition) && 
                (typeof (Nullable<>) == type.GetGenericTypeDefinition());
        }
