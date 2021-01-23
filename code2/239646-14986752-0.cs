    public static class Extensions{
        public static string Scramble(this string s){
            return new string(s.ToCharArray().OrderBy(x=>Guid.NewGuid()).ToArray());
        }
    }
