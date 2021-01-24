    using System;
    using System.IO;
    using System.Threading;
    
    namespace FileSystemWatcherDemo
    {
      class Program
      {
        private static volatile int Count = 0;
        private static FileSystemWatcher Fsw = new FileSystemWatcher
        {
          InternalBufferSize = 48 * 1024,  //  default 8192 bytes, min 4KB, max 64KB
          EnableRaisingEvents = false
        };
        private static void MonitorFolder(string path)
        {
          Fsw.Path = path;
          Fsw.Created += FSW_Add;
          Fsw.Created += FSW_Chg;
          Fsw.Created += FSW_Del;
          Fsw.EnableRaisingEvents = true;
        }
    
        private static void FSW_Add(object sender, FileSystemEventArgs e) { Console.WriteLine($"ADD: {++Count} {e.Name}"); }
        private static void FSW_Chg(object sender, FileSystemEventArgs e) { Console.WriteLine($"CHG: {++Count} {e.Name}"); }
        private static void FSW_Del(object sender, FileSystemEventArgs e) { Console.WriteLine($"DEL: {++Count} {e.Name}"); }
        static void Main(string[] args)
        {
          MonitorFolder(@"C:\Temp\");
          while (true)
          {
            Thread.Sleep(500);
            if (Console.KeyAvailable) break;
          }
          Console.ReadKey();  //  clear buffered keystroke
          Fsw.EnableRaisingEvents = false;
          Console.WriteLine($"{Count} file changes detected");
          Console.ReadKey();
        }
      }
    }
