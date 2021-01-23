    namespace csfunction
    {
      class Program
      {
        static void Main(string[] args)
        {
            int result = AddNumbers(10, 5);
            Console.WriteLine(result);
        }
    
    
          static int AddNumbers(int number1, int number2)
          {
              return number1 + number2;
          }
      }   
    }
