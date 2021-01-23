        public static class TypeExtension
        {
            public static T MinValue<T>(this Type self)
            {
                return (T)self.GetField(nameof(MinValue)).GetRawConstantValue();
            }
    
            public static T MaxValue<T>(this Type self)
            {
                return (T)self.GetField(nameof(MaxValue)).GetRawConstantValue();
            }
        }
