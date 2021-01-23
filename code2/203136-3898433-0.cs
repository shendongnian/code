    private class TypedEnum<T> : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            return GetType().GetFields().Select(f => f.GetValue(null)).OfType<T>().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    private class Combinators : TypedEnum<char>
    {
        public const char DirectChild = '>';
        public const char NextAdjacent = '+';
        public const char NextSiblings = '~';
        public const char Descendant = ' ';
    }
