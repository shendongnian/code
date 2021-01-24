c#
using System.Threading
static void Main()
{
   while(true)
   {
      string input = Console.ReadLine();
      ExecMain(input);
      Thread.Sleep()(2000);
   }
}
