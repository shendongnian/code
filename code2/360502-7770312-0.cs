    static void Main(string[] args)
            {
                string serialnumber = "123456789";
                string macro = "%SERIALNUMBER3%";
    
                var match = Regex.Match(macro, @"\d+");
    
                string parsed = serialnumber.Substring(0, int.Parse(match.ToString()));
            }
