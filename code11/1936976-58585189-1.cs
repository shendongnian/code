public static void Main()
{
    int GetThreadCount() {
        GC.TryStartNoGCRegion(1024*1204*10);
        var count = System.Diagnostics.Process.GetCurrentProcess().Threads.Count;
        GC.EndNoGCRegion();
        return count;
    }
    var count1 = GetThreadCount();
    Console.WriteLine($"Headcount at (in?) the beginning: {count1}");
    var t1 = new Thread(() => {       
            Thread.Sleep(1000);
        });
    t1.Start();
    var count2 = GetThreadCount();
    Console.WriteLine($"Headcount later: {count2}");
    if (count2 != count1 ) {
        Console.WriteLine("Oh no! Threads running!");
    }
    t1.Join();
    var count3 = GetThreadCount();
    Console.WriteLine($"Headcount even later: {count3}");
    if (count3 != count1 ) {
        Console.WriteLine("Oh no! Threads running!");
    } else {
            Console.WriteLine("Phew. Everybody Joined the party.");
    }
    Console.ReadLine();
}
Output
// .NETCoreApp,Version=v3.0
Headcount at (in?) the beginning: 10
Headcount later: 11
Oh no! Threads running!
The thread 9620 has exited with code 0 (0x0).
Headcount even later: 10
Phew. Everybody Joined the party.
