    s= ValidateString(s);    
        static string ValidateString(string s)
        {
            return string.IsNullOrWhiteSpace(s) ? "défault" : s;
        }
