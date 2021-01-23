        public static string[] ParseCsvRow(string csvrow)
        {
            const string obscureCharacter = "ᖳ";
            if (csvrow.Contains(obscureCharacter)) throw new Exception("Error: csv row may not contain the " + obscureCharacter + " character");
            var unicodeSeparatedString = "";
            var quotesArray = csvrow.Split('"');  // Split string on double quote character
            if (quotesArray.Length > 1)
            {
                for (var i = 0; i < quotesArray.Length; i++)
                {
                    // CSV must use double quotes to represent a quote inside a quoted cell
                    // Quotes must be paired up
                    // Test if a comma lays outside a pair of quotes.  If so, replace the comma with an obscure unicode character
                    if (Math.Round(Math.Round((decimal) i/2)*2) == i)
                    {
                        var s = quotesArray[i].Trim();
                        switch (s)
                        {
                            case ",":
                                quotesArray[i] = obscureCharacter;  // Change quoted comma seperated string to quoted "obscure character" seperated string
                                break;
                        }
                    }
                    // Build string and Replace quotes where quotes were expected.
                    unicodeSeparatedString += (i > 0 ? "\"" : "") + quotesArray[i].Trim();
                }
            }
            else
            {
                // String does not have any pairs of double quotes.  It should be safe to just replace the commas with the obscure character
                unicodeSeparatedString = csvrow.Replace(",", obscureCharacter);
            }
            var csvRowArray = unicodeSeparatedString.Split(obscureCharacter[0]); 
            for (var i = 0; i < csvRowArray.Length; i++)
            {
                var s = csvRowArray[i].Trim();
                if (s.StartsWith("\"") && s.EndsWith("\""))
                {
                    csvRowArray[i] = s.Length > 2 ? s.Substring(1, s.Length - 2) : "";  // Remove start and end quotes.
                }
            }
            
            return csvRowArray;
        }
