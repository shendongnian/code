        public static string capString(string instring)
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
            outstring = thisletter.ToString().ToUpper(new CultureInfo("en-US", false));
            if (instring.Length > 1)
            {
                outstring += instring.Substring(1);
            }
            return outstring;
        }
