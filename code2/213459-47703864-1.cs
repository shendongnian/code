        public static string capString(string instring, string culture = "en-US", bool useSystem = false)
        {
            string outstring;
            if (String.IsNullOrWhiteSpace(instring))
            {
                return "";
            }
            instring = instring.Trim();
            char thisletter = instring.First();
            if (!char.IsLetter(thisletter))
            {
                return instring;   
            }
            outstring = thisletter.ToString().ToUpper(new CultureInfo(culture, useSystem));
            if (instring.Length > 1)
            {
                outstring += instring.Substring(1);
            }
            return outstring;
        }
