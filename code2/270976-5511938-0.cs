        public static string FormatTest1(string num)
        {
            string formatPattern = @"(\d{2})(\d{4})(\d{4})(\d{4})(\d{4})";
            return Regex.Replace(num, formatPattern, "$1-$2-$3-$4-$5");
        }
        // test
        string test = FormatTest1("731478718861993983");
        // test result: 73-1478-7188-6199-3983
