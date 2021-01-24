    namespace ConsoleApp1
    {
       class Program
       {
          static void Main(String[] args)
          {
            Decimal dividend = 1234.0m;
            Decimal divisor = 21.1m;`
            for(int ctr = 0; ctr <= 10; ctr++)
            {
               Console.WriteLine("{0:N1} / {1:N1} = {2:N4}", dividend, divisor, Decimal.Divide(dividend, divisor));
               dividend += .1m;
            }
            Console.ReadKey();
          }
       }
    }
