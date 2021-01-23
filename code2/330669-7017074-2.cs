    public class Comparer
    {
        public static bool AreEqualOrZero(params char[] values)
        {
            var firstNonZero = values.FirstOrDefault(x => x != '0');
            return values.All(x => x == firstNonZero || x == '0');
        }
    }
