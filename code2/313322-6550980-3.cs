    public static class Extensions
    {
        public static bool IsEquivalentTo(this Enum e1, Enum e2)
        {
            return e1.ToString() == e2.ToString();
        }
    }
