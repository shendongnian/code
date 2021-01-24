    class ThingToHash
    {
        public bool? CouldBeFalseOrNullOrNull { get; }
        public int IncludesZero { get; }
        public string CanBeEmptyOrNull { get; }
        private string Hidden { get; }
        public ThingToHash(bool? couldBeFalseOrNull, int includesZero, string canBeEmptyOrNull)
        {
            CouldBeFalseOrNullOrNull = couldBeFalseOrNull;
            IncludesZero = includesZero;
            CanBeEmptyOrNull = canBeEmptyOrNull;
        }
    }
    static class StringExtensions
    {
        public static int GetAltHashCode(this string toHash)
        {
            return toHash?.GetHashCode() ?? 17;
        }
    }
    static class NullableBoolExtensions
    {
        public static int GetAltHashCode(this bool? toHash)
        {
            return toHash?.GetAltHashCode() ?? true.GetHashCode() * 19;
        }
    }
    static class BoolExtensions
    {
        public static int GetAltHashCode(this bool toHash)
        {
            if (false == toHash)
            {
                return true.GetHashCode() * 17;
            }
            return toHash.GetHashCode();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(false.GetHashCode());
            Console.WriteLine(((bool?)null).GetHashCode());
            Console.WriteLine(false == (bool?)null);
            Console.WriteLine(HashUnknownObject(new ThingToHash(null, 0, "")));
            Console.WriteLine(HashUnknownObject(new ThingToHash(false, 0, "")));
            Console.ReadKey();
        }
        static int HashUnknownObject(Object toHash)
        {
            PropertyInfo[] members = toHash.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            int hash = 17;
            foreach (PropertyInfo memberToHash in members)
            {
                object memberVal = memberToHash.GetValue(toHash);
                if (null == memberVal)
                {
                    if (typeof(bool?) == memberToHash.PropertyType)
                    {
                        hash += 31 * ((bool?)null).GetAltHashCode();
                    }
                    else if (typeof(string) == memberToHash.PropertyType)
                    {
                        hash += 31 * ((string)null).GetAltHashCode();
                    }
                }
                else
                {
                    hash += 31 * memberToHash.GetValue(toHash).GetHashCode();
                }
            }
            return hash;
        }
    }
