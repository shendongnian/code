        public static string ReverseWords(string originalString)
        {
            originalString = originalString.TrimEnd('.');
            originalString = string.Join(" ", originalString.Split(' ').Where(x => !string.IsNullOrEmpty(x)).Reverse());
            return originalString + ".";
        }
