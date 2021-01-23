    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using System.Threading;
    
    class CaptureProcessOutput
    {
        private ManualResetEvent m_processExited = new ManualResetEvent(false);
        private List<string> m_errorMessages = new List<string>();
        private List<string> m_regularMessages = new List<string>();
        private Process m_process = new Process(); 
            
        public CaptureProcessOutput()
        {
        }
        
        public void Run (string[] args)
        {
            StringBuilder sb = new StringBuilder("/COVERAGE "); 
            sb.Append("hello.exe"); 
            m_process.StartInfo.FileName = "vsinstr.exe"; 
            m_process.StartInfo.Arguments = sb.ToString(); 
            m_process.StartInfo.UseShellExecute = false;
            
            m_process.Exited += this.ProcessExited;
            
            m_process.StartInfo.RedirectStandardError = true;
            m_process.StartInfo.RedirectStandardOutput = true;
            
            m_process.ErrorDataReceived += this.ErrorDataHandler;
            m_process.OutputDataReceived += this.OutputDataHandler;
            
            m_process.BeginErrorReadLine();
            m_process.BeginOutputReadLine();
    
            m_process.Start();
            
            m_processExited.WaitOne();
        }
    
        private void ErrorDataHandler(object sender, DataReceivedEventArgs args)
        {
            string message = args.Data;
            
            if (message.StartsWith("Error"))
            {
                // The vsinstr.exe process reported an error
                m_errorMessages.Add(message);
            }
        }
        
        private void OutputDataHandler(object sender, DataReceivedEventArgs args)
        {
            string message = args.Data;
    
            m_regularMessages.Add(message);
        }
                
        private void ProcessExited(object sender, EventArgs args)
        {
            // This is where you can add some code to be
            // executed before this program exits.
            m_processExited.Set();
        }
        
        public static void Main (string[] args)
        {
            CaptureProcessOutput cpo = new CaptureProcessOutput();
            cpo.Run(args);
        }
    }
