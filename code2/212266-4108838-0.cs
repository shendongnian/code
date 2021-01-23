    public static class FlagsHelper
    {
        public static bool HasFlag(this Enum keys, Enum flag);
        {
            return keys & flag == flag;
        }
    }
