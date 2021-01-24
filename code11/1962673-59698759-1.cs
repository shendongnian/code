    using System;
    using System.Diagnostics;
    using System.Linq; 
    using System.Timers;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            { 
                var notepadPlusPlus = new Process();
                notepadPlusPlus.StartInfo.FileName = @"C:\Program Files\Notepad++\notepad++.exe";
                notepadPlusPlus.Start(); 
                var processWatcher = new ProcessWatcher(Execute, notepadPlusPlus.ProcessName, 2000);
                processWatcher.StartWatch();
                Console.WriteLine("To exit press any key. Currently awiating Noptepad++.exe. to exit.");
                Console.ReadLine();
            }
            public static void Execute()
            {
                Console.WriteLine("The Notepad++.exe has been closed. Starting Notepad.exe");
                var notepad = new Process();
                notepad.StartInfo.FileName = @"C:\Windows\System32\notepad.exe";
                notepad.Start(); 
            }
       }
       public class ProcessWatcher
       {
           private readonly string _processName;
           private readonly Action _callbackMethod;
           private Timer _scanTimer;
           public ProcessWatcher(Action callbackMethod, string processName, int scanInterval)
           {
                _processName = processName;
                _callbackMethod = callbackMethod;
               _scanTimer = new Timer(scanInterval);
               _scanTimer.Elapsed += _scanTimer_Elapsed;
           }
           public void StartWatch()
           {
                _scanTimer.Start();
                _scanTimer.AutoReset = true;
           }
           public void StopWatch()
           {
               _scanTimer.Stop();
           }
           private void _scanTimer_Elapsed(object sender, ElapsedEventArgs e)
           {
                var processes = Process.GetProcessesByName(_processName);
                if (!processes.Any())
                {
                    _callbackMethod.Invoke();
                    StopWatch();
                }
           }
        }
    }
