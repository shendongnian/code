       public static bool IsInteger(this string inputString)
        {
            Regex regexInteger = new Regex(@"^[-]?\d+$");
            Match m = regexInteger.Match(inputString);
            return m.Success;
        }
