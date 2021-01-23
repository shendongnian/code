    using System;
    using System.Diagnostics;
    using System.IO;
    using Mono.Unix;
    
    class Test
    {
        public static void Main()
        {
            int reading, writing;
            Mono.Unix.Native.Syscall.pipe(out reading, out writing);
            int stdout = Mono.Unix.Native.Syscall.dup(1);
            Mono.Unix.Native.Syscall.dup2(writing, 1);
            Mono.Unix.Native.Syscall.close(writing);
    
            Process cmdProcess = new Process();
            ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
            cmdStartInfo.FileName = "cat";
            cmdStartInfo.CreateNoWindow = true;
            cmdStartInfo.Arguments = "test.exe";
            cmdProcess.StartInfo = cmdStartInfo;
            cmdProcess.Start();
    
            Mono.Unix.Native.Syscall.dup2(stdout, 1);
            Mono.Unix.Native.Syscall.close(stdout);
    
            Stream s = new UnixStream(reading);
            byte[] buf = new byte[1024];
            int bytes = 0;
            int current;
            while((current = s.Read(buf, 0, buf.Length)) > 0)
            {
                bytes += current;
            }
            Mono.Unix.Native.Syscall.close(reading);
            Console.WriteLine("{0} bytes read", bytes);
        }
    }
