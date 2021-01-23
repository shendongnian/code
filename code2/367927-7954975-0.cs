        static void Main(string[] args)
        {
            var id = "843342D4343DA123D";
            var intSummand = 10;
            Console.WriteLine(AddToStringId(id, intSummand));
            Console.ReadKey();
        }
        static string AddToStringId(string id, int summand)
        {             
            var intPos = id.Length;
            for (int i = id.Length - 1; i >= 0; i--)
            {
                var charTmp = id.Substring(i, 1).ToCharArray()[0];
                if (char.IsNumber(charTmp))
                    intPos--;
                else
                    break;
            }
            var numberString = string.Empty;
            if (intPos < id.Length)
                numberString = id.Substring(intPos, id.Length - intPos);
            if (numberString.Length == 0)
                id += summand.ToString();
            else
            {
                id = id.Substring(0, id.Length - numberString.Length);
                id += int.Parse(numberString) + summand;
            }
            return id;
        }
