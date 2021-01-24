csharp
static async Task Main(string[] args)
{
   PrintMessages();
   
   Console.WriteLine("Past The Async");
}
public static async Task PrintMessages()
{
   await foreach (var item in MessagesAsync())
   {
       Console.WriteLine(item);
   }
}
But if you do that, your program will terminate as soon as ```Main``` exits, so you might actually want to wait, or maybe you have some other work you can perform.
