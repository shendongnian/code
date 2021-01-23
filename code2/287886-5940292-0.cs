    public class Utils
    {
        public static IEnumerable<string> GetSequenceEntries(long maxValue)
        {
            yield return string.Empty;
            for(int i=1; i<=maxValue; i++)
            {
                yield return i.ToString();
            }
        }
    }
