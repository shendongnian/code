    public abstract class Helper<T>
    {
        static Dictionary<Type, T> s_defaults = new Dictionary<Type, T>();
        
        public static string DoSomething<TEnum>(TEnum value) where TEnum: struct, T
        {
            if (!Enum.IsDefined(typeof(TEnum), value))
            {
                value = GetDefault<TEnum>();
            }
            // ... do some other stuff
            // just to get code to compile
            return value.ToString();
        }
        
        public static TEnum GetDefault<TEnum>() where TEnum : struct, T
        {
            T definedDefault;
            if (!s_defaults.TryGetValue(typeof(TEnum), out definedDefault))
            {
                // This is the only time you'll have to box the defined default.
                definedDefault = (T)Enum.GetValues(typeof(TEnum)).GetValue(0);
                s_defaults[typeof(TEnum)] = definedDefault;
            }
            
            // Every subsequent call to GetDefault on the same TEnum type
            // will unbox the same object.
            return (TEnum)definedDefault;
        }
    }
