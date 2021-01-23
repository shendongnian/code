    public static class Extensions
    {
        public static bool IsEquivalentTo<TEnum1,TEnum2>(this TEnum1 e1, TEnum2 e2) where TEnum1 : Enum where TEnum2 : Enum
        {
            return e1.ToString() == e2.ToString();
        }
    }
