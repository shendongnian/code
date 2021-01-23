    public class Program
    {
        static void Main()
        {
            var psi = new ProcessStartInfo
            {
                FileName = @"c:\windows\system32\netstat.exe",
                Arguments = "-n",
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            var process = Process.Start(psi);
            while (!process.HasExited)
            {
                Thread.Sleep(100);
            }
    
            Console.WriteLine(process.StandardOutput.ReadToEnd());
        }
    }
