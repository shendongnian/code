    private static string CapitaliseFirstLetter(string str)
        {
            var Ustr = string.Empty;
            if (!String.IsNullOrEmpty(str))
            {
                Ustr = char.ToUpper(str.First()) + str.Substring(1).ToLower();
            }
             
            return Ustr;
        }
