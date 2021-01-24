c#
static void Main()
{
   while(true)
   {
      string input = Console.ReadLine();
      ExecMain(input);
      Task.Delay(2000);
   }
}
