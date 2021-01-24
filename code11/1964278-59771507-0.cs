    static void Main(string[] args)
        {
            Console.Title = "Main app...";
            Console.WriteLine("This is the message for the main console application.");
            using (var process1 = new Process())
            {
                process1.StartInfo.UseShellExecute = true;
                process1.StartInfo.CreateNoWindow = false;
                process1.StartInfo.FileName = @"../../../../ConsoleAppAdditional/bin\Debug\netcoreapp3.1/ConsoleAppAdditional.exe";
                process1.Start();
            }
            using (var process2 = new Process())
            {
                process2.StartInfo.UseShellExecute = true;
                process2.StartInfo.CreateNoWindow = false;
                process2.StartInfo.FileName = @"../../../../ConsoleAppAdditional/bin\Debug\netcoreapp3.1/ConsoleAppAdditional.exe";
                process2.Start();
            }
            Console.WriteLine("Press ENTER (MainApp) for exit...");
            Console.ReadLine();
        }
