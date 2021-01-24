c#
using System.Threading
static void Main()
{
   string input = Convert.ToInt32(Console.ReadLine());
   while(true)
   {
      Console.Clear();
      ExecMain(input);
      Thread.Sleep(2000);
   }
}
