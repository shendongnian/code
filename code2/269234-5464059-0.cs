    public static class EnumExtensions
    {
        public static bool Get(this Enum theEnum, Enum flag)
        {
            var flagsAttributes = theEnum.GetType().GetCustomAttributes(typeof(FlagsAttribute), false);
            if (flagsAttributes.Length == 0)
                return false; // not a [Flags] enum
    
            return theEnum.HasFlag(flag);
        }
    }
