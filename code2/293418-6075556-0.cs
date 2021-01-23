    namespace Sandbox
    {
      using System ;
      class Program
      {
        static void Main( string[] args )
        {
          decimal pi     = (decimal) Math.PI ;
          string  piText = pi.ToString("0.00");
          Console.WriteLine("PI to 2 decimal places is {0} one way, and {1:0.00} another" , piText , pi ) ;
          return;
        }
      }
    }
