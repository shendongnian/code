    static void Sort()
    {
        string[] partNumbers = new string[] {"A1", "A2", "A10", "A111"};
        string[] result = partNumbers.OrderBy(x => PadNumbers(x)).ToArray();
    }
    public static string PadNumbers(string input)
    {
            const int MAX_NUMBER_LEN = 10;
            string newInput = "";
            string currentNumber = "";
            foreach (char a in input)
            {
                if (!char.IsNumber(a))
                {
                    if (currentNumber == "")
                    {
                        newInput += a;
                        continue;
                    }
                    newInput += "0000000000000".Substring(0, MAX_NUMBER_LEN - currentNumber.Length) + currentNumber;
                    currentNumber = "";
                }
                currentNumber += a;
            }
            if (currentNumber != "")
            {
                newInput += "0000000000000".Substring(0, MAX_NUMBER_LEN - currentNumber.Length) + currentNumber;
            }
            return newInput;
        }
~ 
