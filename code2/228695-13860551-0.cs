        private delegate void DataRead(string data);
        private static event DataRead OnDataRead;
        static void Main(string[] args)
        {
            OnDataRead += data => Console.WriteLine(data != null ? data : "Program finished");
            Thread readingThread = new Thread(Read);
            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = Environment.GetCommandLineArgs()[0],
                Arguments = "/arg1 arg2",
                RedirectStandardOutput = true,
                UseShellExecute = false,
            };
            using (Process process = Process.Start(info))
            {
                readingThread.Start(process);
                process.WaitForExit();
            }
            readingThread.Join();
        }
        private static void Read(object parameter)
        {
            Process process = parameter as Process;
            char[] buffer = new char[Console.BufferWidth];
            int read = 1;
            while (read > 0)
            {
                read = process.StandardOutput.Read(buffer, 0, buffer.Length);
                string data = read > 0 ? new string(buffer, 0, read) : null;
                if (OnDataRead != null) OnDataRead(data);
            }
        }
