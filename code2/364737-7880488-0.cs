        static void Main(string[] args)
        {
            string test1 = "bc3231dsc";
            string tes2 = "bc3462dsc";
            string firstmatch = GetMatch(test1, tes2, false);
            string lasttmatch = GetMatch(test1, tes2, true);
        }
        public static string GetMatch(string fist, string second, bool isReverse)
        {
            if (isReverse)
            {
                fist = ReverseString(fist);
                second = ReverseString(second);
            }
            StringBuilder builder = new StringBuilder();
            char[] ar1 = fist.ToArray();
            for (int i = 0; i < ar1.Length; i++)
            {
                if (fist.Length > i + 1 && ar1[i].Equals(second[i]))
                {
                    builder.Append(ar1[i]);
                }
                else
                {
                    break;
                }
            }
            if (isReverse)
            {
                return ReverseString(builder.ToString());
            }
            return builder.ToString();
        }
        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
