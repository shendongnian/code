    namespace ExtensionMethods
    {
        public static class IntExtensions
         {
            public static int ToMinutes(this int time)
            {
    			return time / 100 * 60 + time - time / 100 * 100;
            }
        }
    }
