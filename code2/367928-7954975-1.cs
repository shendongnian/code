        static void Main(string[] args)
        {
            var id = "843342D4343DA123D";
            var intSummand = 10;
            Console.WriteLine(AddToStringId(id, intSummand));
            Console.ReadKey();
        }
        static string AddToStringId(string id, int summand)
        {                         
            // set the begin-pointer of for the number to the end of the original id
            var intPos = id.Length;
            // go back from end of id to the begin while a char is a number
            for (int i = id.Length - 1; i >= 0; i--)
            {
                var charTmp = id.Substring(i, 1).ToCharArray()[0];
                if (char.IsNumber(charTmp))
                {
                    // set the position one element back
                    intPos--;
                }
                else
                {
                    // we found a char and so we can break up
                    break;
                }
            }
            var numberString = string.Empty;
            if (intPos < id.Length)
            {
                // the for-loop has found at least one numeric char at the end
                numberString = id.Substring(intPos, id.Length - intPos);
            }
            if (numberString.Length == 0)
            {
                // no number was found at the and so we simply add the summand as string
                id += summand.ToString();
            }
            else
            {
                // cut off the id-string up to the last char before the number at the end
                id = id.Substring(0, id.Length - numberString.Length);
                // add the Increment-operation-result to the end of the id-string and replace
                // the value which stood there before
                id += (int.Parse(numberString) + summand).ToString();
            }
            // return the result
            return id;
        }
