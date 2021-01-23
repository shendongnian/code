    public static class EnumExtensions
    {
        public static T SetFlags<T>(this T value, T flags, bool on) where T : struct
        {    
            long lValue = Convert.ToInt64(value);
            long lFlag = Convert.ToInt64(flags);
            if (on)
            {
                lValue |= lFlag;
            }
            else
            {
                lValue &= (~lFlag);
            }
            return (T)Enum.ToObject(typeof(T), lValue);
        }
    }
    
