csharp
static void Main(string[] args)
{
    Task task = null;
    for (int i = 0; i < 10; i++)
    {
        if (i == 1)
        {
            task = Task.Run(() => {
                    Thread.Sleep(60000);
                    Console.WriteLine("1");
                }
            );
                    
        }
        else if (i == 2)
        {
            Console.WriteLine("2");
        }
        else if (i == 3)
        {
            Console.WriteLine("3");
        }
    }
    task.Wait();
}
But I'm pretty sure that you need much more understanding, how the threads work. Good luck :)
