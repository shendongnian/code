    using System;
    using System.Diagnostics;
    using System.Text;
    using System.Threading;
    
    namespace SonomaTechnologyInc {
        /// <summary>
        /// Utility class for working with command-line programs.
        /// </summary>
        public class Subprocess {  
            private Subprocess() { }
    
            /// <summary>
            /// Executes a command-line program, specifying a maximum time to wait
            /// for it to complete.
            /// </summary>
            /// <param name="command">
            /// The path to the program executable.
            /// </param>
            /// <param name="args">
            /// The command-line arguments for the program.
            /// </param>
            /// <param name="timeout">
            /// The maximum time to wait for the subprocess to complete, in milliseconds.
            /// </param>
            /// <returns>
            /// A <see cref="SubprocessResult"/> containing the results of
            /// running the program.
            /// </returns>
            public static SubprocessResult RunProgram(string command, string args, int timeout) {
                bool timedOut = false;
                ProcessStartInfo pinfo = new ProcessStartInfo(command);
                pinfo.Arguments = args;
                pinfo.UseShellExecute = false;
                pinfo.CreateNoWindow = true;
                //pinfo.WorkingDirectory = ?
                pinfo.RedirectStandardOutput = true;
                pinfo.RedirectStandardError = true;
                Process subprocess = Process.Start(pinfo);
    
                ProcessStream processStream = new ProcessStream();
                try {
                    processStream.Read(subprocess);
    
                    subprocess.WaitForExit(timeout);
                    processStream.Stop();
                    if(!subprocess.HasExited) {
                        // OK, we waited until the timeout but it still didn't exit; just kill the process now
                        timedOut = true;
                        try {
                            subprocess.Kill();
                            processStream.Stop();
                        } catch { }
                        subprocess.WaitForExit();
                    }
                } catch(Exception ex) {
                    subprocess.Kill();
                    processStream.Stop();
                    throw ex;
                } finally {
                    processStream.Stop();
                }
    
                TimeSpan duration = subprocess.ExitTime - subprocess.StartTime;
                float executionTime = (float) duration.TotalSeconds;
                SubprocessResult result = new SubprocessResult(
                    executionTime, 
                    processStream.StandardOutput.Trim(), 
                    processStream.StandardError.Trim(), 
                    subprocess.ExitCode, 
                    timedOut);
                return result;
            }
        }
    
        /// <summary>
        /// Represents the result of executing a command-line program.
        /// </summary>
        public class SubprocessResult {
            readonly float executionTime;
            readonly string stdout;
            readonly string stderr;
            readonly int exitCode;
            readonly bool timedOut;
    
            internal SubprocessResult(float executionTime, string stdout, string stderr, int exitCode, bool timedOut) {
                this.executionTime = executionTime;
                this.stdout = stdout;
                this.stderr = stderr;
                this.exitCode = exitCode;
                this.timedOut = timedOut;
            }
    
            /// <summary>
            /// Gets the total wall time that the subprocess took, in seconds.
            /// </summary>
            public float ExecutionTime {
                get { return executionTime; }
            }
    
            /// <summary>
            /// Gets the output that the subprocess wrote to its standard output stream.
            /// </summary>
            public string Stdout {
                get { return stdout; }
            }
    
            /// <summary>
            /// Gets the output that the subprocess wrote to its standard error stream.
            /// </summary>
            public string Stderr {
                get { return stderr; }
            }
    
            /// <summary>
            /// Gets the subprocess's exit code.
            /// </summary>
            public int ExitCode {
                get { return exitCode; }
            }
    
            /// <summary>
            /// Gets a flag indicating whether the subprocess was aborted because it
            /// timed out.
            /// </summary>
            public bool TimedOut {
                get { return timedOut; }
            }
        }
    
        internal class ProcessStream {
            /*
             * Class to get process stdout/stderr streams
             * Author: SeemabK (seemabk@yahoo.com)
             * Usage:
                //create ProcessStream
                ProcessStream myProcessStream = new ProcessStream();
                //create and populate Process as needed
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = "myexec.exe";
                myProcess.StartInfo.Arguments = "-myargs";
    
                //redirect stdout and/or stderr
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo.RedirectStandardError = true;
    
                //start Process
                myProcess.Start();
                //connect to ProcessStream
                myProcessStream.Read(ref myProcess);
                //wait for Process to end
                myProcess.WaitForExit();
    
                //get the captured output :)
                string output = myProcessStream.StandardOutput;
                string error = myProcessStream.StandardError;
             */
            private Thread StandardOutputReader;
            private Thread StandardErrorReader;
            private Process RunProcess;
            private string _StandardOutput = "";
            private string _StandardError = "";
    
            public string StandardOutput {
                get { return _StandardOutput; }
            }
            public string StandardError {
                get { return _StandardError; }
            }
    
            public ProcessStream() {
                Init();
            }
    
            public void Read(Process process) {
                try {
                    Init();
                    RunProcess = process;
    
                    if(RunProcess.StartInfo.RedirectStandardOutput) {
                        StandardOutputReader = new Thread(new ThreadStart(ReadStandardOutput));
                        StandardOutputReader.Start();
                    }
                    if(RunProcess.StartInfo.RedirectStandardError) {
                        StandardErrorReader = new Thread(new ThreadStart(ReadStandardError));
                        StandardErrorReader.Start();
                    }
    
                    int TIMEOUT = 1 * 60 * 1000; // one minute
                    if(StandardOutputReader != null)
                        StandardOutputReader.Join(TIMEOUT);
                    if(StandardErrorReader != null)
                        StandardErrorReader.Join(TIMEOUT);
    
                } catch { }
            }
    
            private void ReadStandardOutput() {
                if(RunProcess == null) return;
                try {
                    StringBuilder sb = new StringBuilder();
                    string line = null;
                    while((line = RunProcess.StandardOutput.ReadLine()) != null) {
                        sb.Append(line);
                        sb.Append(Environment.NewLine);
                    }
                    _StandardOutput = sb.ToString();
                } catch { }
            }
    
            private void ReadStandardError() {
                if(RunProcess == null) return;
                try {
                    StringBuilder sb = new StringBuilder();
                    string line = null;
                    while((line = RunProcess.StandardError.ReadLine()) != null) {
                        sb.Append(line);
                        sb.Append(Environment.NewLine);
                    }
                    _StandardError = sb.ToString();
                } catch { }
            }
    
            private void Init() {
                _StandardError = "";
                _StandardOutput = "";
                RunProcess = null;
                Stop();
            }
    
            public void Stop() {
                try { if(StandardOutputReader != null) StandardOutputReader.Abort(); } catch { }
                try { if(StandardErrorReader != null) StandardErrorReader.Abort(); } catch { }
                StandardOutputReader = null;
                StandardErrorReader = null;
            }
        }
    }
