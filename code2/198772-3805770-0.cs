    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Opening....");
    
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = @"c:\program.exe";
            startInfo.Arguments = @"file.txt";
    
            var p = Process.Start(startInfo);
            p.WaitForExit();
    
            Console.WriteLine("Closed");
            Console.ReadLine();
        }
    
    }
