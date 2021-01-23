        public string swap_string(string str)
        {
            Regex classRegex = new Regex(@"class=""(.+?)""");
            Regex idRegex = new Regex(@"id=""(.+?)""");
            string classVal = classRegex.Match(str).Value;
            string idVal = idRegex.Match(str).Value;
            str = classRegex.Replace(str, "__TMPSTRING__");
            str = idRegex.Replace(str, classVal);
            str = str.Replace("__TMPSTRING__", idVal);
            return str;
        }
