    private string ConvertToWesternArbicNumerals(string input)
        {
            var result = new StringBuilder(input.Length);
            foreach (char c in input.ToCharArray())
            {
                //Check if the characters is recognized as UNICODE numeric value if yes
                if (char.IsNumber(c))
                {
                    // using char.GetNumericValue() convert numeric Unicode to a double-precision 
                    // floating point number (returns the numeric value of the passed char)
                    // apend to final string holder
                    result.Append(char.GetNumericValue(c));
                }
                else
                {
                    // apend non numeric chars to recreate the orignal string with the converted numbers
                    result.Append(c);
                }
            }
            return result.ToString();
        }
 
