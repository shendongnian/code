    static void Main(string[] args)
        {
            String Calculation = "2 * 5 * 7 * 6 / 4 + 2"; ///The calculation, you can take this from txtBox
            CalculationEngine engine = new CalculationEngine(); /// Creating a new calculatorEngine
            var result = engine.Evaluate(Calculation); ///Evaluate the calculation, and store it in a "var"
            Console.WriteLine(result);  ///Result is 107
            Console.ReadKey(); 
        }
