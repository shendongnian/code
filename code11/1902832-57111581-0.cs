    public static class StringExtensions {
        public static int CountTrailingSpaces(this string s) {
            int count = 0;
            for (int i = s.Length- 1; i >= 0; i--) {
                if (Char.IsWhiteSpace(s[i])) {
                    count++;
                }
                else {
                    return count;
                }
            }
            return count;
        }
        public static int CountTrailingSpacesLinq(this string s) {
            return s.Reverse().TakeWhile(Char.IsWhiteSpace).Count();
        }
    }
