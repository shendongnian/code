       namespace csfunction
        {
            class Program
            {
                static void Main(string[] args)
                {
                  AddNumbers(8,5);
                }
                public int AddNumbers(int number1, int number2)
                {
                  int result = AddNumbers(10, 5);
                  Console.WriteLine(result);    
                }
            } 
        }
