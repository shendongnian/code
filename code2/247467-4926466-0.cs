    public static class StringExtensions {
        public static IEnumerable<string> TakeEvery(this string s, int count) {
            int index = 0;
            while(index < s.Length) {
                if(s.Length - index >= count) {
                    yield return s.Substring(index, count);
                }
                else {
                    yield return s.Substring(index, s.Length - index);
                }
                index += count;
            }
        }
    }
