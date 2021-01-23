    public static class StringExtensions
    {
        public static IEnumerable<string> TakeEvery(this string s, int count)
        {
            
            int index = 0;
            while (index < s.Length)
            {
                if (index + count >= s.Length)
                {
                    yield return s.Substring(index, s.Length - index);
                }
                else
                {
                    yield return s.Substring(index, count);
                }
                index += count;
            }
        }
    }
   
