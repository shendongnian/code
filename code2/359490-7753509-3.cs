    class Program
    {
        static void Main(string[] args)
        {
            int i = 31240;
            string StringRepresentation = ((double)i / 1000).ToString("0.#k");
            int resultBackWithParse = int.Parse(StringRepresentation.Substring(0, StringRepresentation.Length - 1).Replace(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, string.Empty)) * 100;
            Console.WriteLine("Base number: " + i.ToString());
            Console.WriteLine(new string('-', 35));
            Console.WriteLine("String representation: " + StringRepresentation);
            Console.WriteLine("Int representation With Int.Parse: " + resultBackWithParse.ToString());
            Console.WriteLine();
            StringFromInt MySolutionNumber = i;
            int resultBackWithStringFromInt = MySolutionNumber;
            Console.WriteLine("String representation With StringFromInt: " + MySolutionNumber.ToString());
            Console.WriteLine("Int representation With StringFromInt: " + resultBackWithStringFromInt);
            Console.WriteLine(new string('=', 35) + "\n");
            i = 123456789;
            StringFromInt MyNumber = 123456789;
            int resultBack = MyNumber;
            Console.WriteLine("Base number: " + i.ToString());
            Console.WriteLine(new string('-', 35));
            Console.WriteLine("String representation With StringFromInt: " + MyNumber);
            Console.WriteLine("Int representation With StringFromInt: " + resultBack);
            Console.ReadKey(true);
        }
    }
