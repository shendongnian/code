    using System;
    using System.Diagnostics;
    using System.IO;
    
    namespace Example
    {
        public sealed class CommandLineProcess : IDisposable
        {
            public string Path { get; }
            public string Arguments { get; }
            public bool IsRunning { get; private set; }
            public int? ExitCode { get; private set; }
    
            private Process Process;
            private readonly object Locker = new object();
    
            public CommandLineProcess(string path, string arguments)
            {
                Path = path ?? throw new ArgumentNullException(nameof(path));
                if (!File.Exists(path)) throw new ArgumentException($"Executable not found: {path}");
                Arguments = arguments;
            }
    
            public int Run(out string output, out string err)
            {
                lock (Locker)
                {
                    if (IsRunning) throw new Exception("The process is already running");
    
                    Process = new Process()
                    {
                        EnableRaisingEvents = true,
                        StartInfo = new ProcessStartInfo()
                        {
                            FileName = Path,
                            Arguments = Arguments,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            CreateNoWindow = true,
                        },
                    };
    
                    if (!Process.Start()) throw new Exception("Process could not be started");
                    output = Process.StandardOutput.ReadToEnd();
                    err = Process.StandardError.ReadToEnd();
                    Process.WaitForExit();
                    try { Process.Refresh(); } catch { }
                    return (ExitCode = Process.ExitCode).Value;
                }
            }
    
            public void Kill()
            {
                lock (Locker)
                {
                    try { Process?.Kill(); }
                    catch { }
                    IsRunning = false;
                    Process = null;
                }
            }
    
            public void Dispose()
            {
                try { Process?.Dispose(); }
                catch { }
            }
        }
    }
