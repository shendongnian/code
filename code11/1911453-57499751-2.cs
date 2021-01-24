c#
using System.Threading
static void Main()
{
   string input = Console.ReadLine();
   while(true)
   {
      ExecMain(input);
      Thread.Sleep(2000);
   }
}
