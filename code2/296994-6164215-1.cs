    namespace SO_Console_test
    {
        class Program
        {
            static void Main(string[] args)
            {    
                showConversion();
                Console.ReadLine();
                
            }
    
            private static void showConversion()
            {
                //simple start:
                Console.WriteLine("6ft 2\"".ImperialToMetric().ToString() + " mm");
    
                //more robust:
                var Imperials = new List<string>(){"6 inches",
                    "6in",
                    "6”",
                    "4 feet 2 inches",
                    "4’2”",
                    "4 ‘ 2 “",
                    "3 feet",
                    "3’",
                    "3 ‘",
                    "3ft",
                    "3ft10in",
                    "3ft 13in"};
    
                foreach (string imperial in Imperials)
                {
                    Console.WriteLine(imperial + " converted to " + imperial.ImperialToMetric() + " millimeters");
                }
    
    
            }
    }
