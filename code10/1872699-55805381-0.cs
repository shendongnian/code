        static void Main(string[] args)
        {
            var myDouble = EnterSomething<double>("a double", double.TryParse);
            var myInt = EnterSomething<int>("an interger", int.TryParse);
            Console.WriteLine(myDouble);
            Console.WriteLine(myInt);
            Console.ReadLine();
        }
        public delegate bool TryParseFunction<Tin, Tout>(Tin input, out Tout output);
        public static Tout EnterSomething<Tout>(string typeName, TryParseFunction<string, Tout> parser)
        {
            while (true)
            {
                Console.Write("Enter " + typeName + " number: ");
                if (parser(Console.ReadLine(), out Tout number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Incorrect value");
                }
            }
        }
