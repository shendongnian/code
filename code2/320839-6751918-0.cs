    public static class Extensions
    {
        public static IEnumerable<T> ReplaceSequence<T>(this IEnumerable<T> original, IEnumerable<T> toSearch, IEnumerable<T> toReplace) where T : IEquatable<T>
        {
            T[] toSearchItems = toSearch.ToArray();
            List<T> window = new List<T>();
            foreach (T value in original)
            {
                window.Add(value);
                if (window.Count == toSearchItems.Length)
                {
                    bool match = true;
                    for (int i = 0; i < toSearchItems.Length; i++)
                    {
                        if (!toSearchItems[i].Equals(window[i]))
                        {
                            match = false;
                            break;
                        }
                    }
                    if (match)
                    {
                        foreach (T toReplaceValue in toReplace)
                        {
                            yield return toReplaceValue;
                        }
                        window.Clear();
                    }
                    else
                    {
                        yield return window[0];
                        window.RemoveAt(0);
                    }
                }
            }
            foreach (T value in window)
            {
                yield return value;
            }
        }
    }
    // http://stackoverflow.com/q/6751533/751090
    public class StackOverflow_6751533
    {
        public static void Test()
        {
            byte[] byteArray = new byte[] { 0x01, 0x02, 0x7E, 0x7E, 0x04 };
            byte[] escapeSequence = new byte[] { 0x7E, 0x7E };
            byte[] unescapedSequence = new byte[] { 0x7E };
            byte[] outputBytes = byteArray.ReplaceSequence(escapeSequence, unescapedSequence).ToArray();
            for (int i = 0; i < outputBytes.Length; i++)
            {
                Console.Write("{0:X2} ", (int)outputBytes[i]);
            }
            Console.WriteLine();
        }
    }
