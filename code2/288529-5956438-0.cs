    public static class Extensions
    {
        [Obsolete("Do Not Use", true)]
        public static int Squared(this Dummy Dummy)
        {
            return Dummy.x * Dummy.x;
        }
    }
