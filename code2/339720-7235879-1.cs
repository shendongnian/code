        public static string[] SplitIntoNumbers(string input)
        {
            List<string> result = new List<string>();
            string[] subStrs = input.Split(new char[] { '\r', '\n' }, 3, StringSplitOptions.RemoveEmptyEntries);
            for (int it = 0; it < subStrs[0].Length; it += 3)
            {
                result.Add(subStrs[0].Substring(it, 3)
                    + subStrs[1].Substring(it, 3)
                    + subStrs[2].Substring(it, 3));
            }
            return result.ToArray();
        }
