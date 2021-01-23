    public class TypedEnum<TBase, TValue>
    {
        public static IEnumerable<TValue> ToEnumerable()
        {
            return typeof (TBase).GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(f => f.GetValue(null)).OfType<TValue>();
        }
        public static TValue[] ToArray()
        {
            return ToEnumerable().ToArray();
        }
        public static string Pattern
        {
            get
            {
                return string.Format("(?:{0})", string.Join("|", ToEnumerable().Select(c => Regex.Escape(c.ToString()))));
            }
        }
    }
    public class Combinators : TypedEnum<Combinators, char>
    {
        public const char DirectChild = '>';
        public const char NextAdjacent = '+';
        public const char NextSiblings = '~';
        public const char Descendant = ' ';
    }
