public static void Main()
{
    Console.WriteLine($"START");
    var t = new Thread(() =>
    {
        var m = new MyCls();
    });
    Console.WriteLine($"t.Start");
    t.Start();
    Thread.Sleep(2000);
    Console.WriteLine($"Trying to create a new object");
    try
    {
        var m2 = new MyCls();
    }
    catch (Exception ex) { Console.WriteLine(ex); }
    Console.WriteLine("All done");
    Console.ReadLine();
}
public class MyCls
{
    static MyCls()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i == 4)
            {
                Console.WriteLine($"sctor calling Abort on itself");
                Thread.CurrentThread.Abort();
            };
            Console.WriteLine($"sctor.{i}");
            Thread.Sleep(100);
        }
    }
}
## Output
START
t.Start
sctor.0
sctor.1
sctor.2
sctor.3
sctor calling Abort on itself
Trying to create a new object
System.TypeInitializationException: The type initializer for 'MyCls' threw an exception. ---> System.Threading.ThreadAbortException: Thread was being aborted.
   at System.Threading.Thread.AbortInternal()
   at System.Threading.Thread.Abort()
   at Program.MyCls..cctor() in c:\users\letss\source\repos\ConsoleApp2\ConsoleApp2\Program.cs:line 42
   --- End of inner exception stack trace ---
   at Program.MyCls..ctor()
   at Program.Main() in c:\users\letss\source\repos\ConsoleApp2\ConsoleApp2\Program.cs:line 21
All done
