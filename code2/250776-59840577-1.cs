    using AllInOne;
    
    namespace UsingDLLinApplication
    {
        public class GetResult
        {
            static void Main()
            {
                Calculate myEveryCalculation = new Calculate();
                double storeAreaOFSquare = myEveryCalculation.GetAreaOfSquare(4.5);
                Console.WriteLine("The area of Square is {0}", storeAreaOFSquare);
                Console.ReadLine();
            }
         }
    }
