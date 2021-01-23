    namespace Canvas
    {
      class Program
      {
        static void Main(string[] args)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod());
            DiscreteMathOperations viola = new DiscreteMathOperations();
            int resultOfSummation = 0;
            resultOfSummation = viola.ConsecutiveIntegerSummation(1, 100);
            Console.WriteLine(resultOfSummation);
        }
    }
    public class DiscreteMathOperations
    {
        public int ConsecutiveIntegerSummation(int startingNumber, int endingNumber)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod());
            int result = 0;
            result = (startingNumber * (endingNumber + 1)) / 2;
            return result;
        }
    }    
    }
