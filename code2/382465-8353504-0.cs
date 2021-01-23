    public class ProcessOutputHandler
    {
        public Process proc { get; set; }
        public string StdOut { get; set; }
        public string StdErr { get; set; }
        private IVsOutputWindowPane _pane;
        private BackgroundWorker _worker;
        /// <summary>  
        /// The constructor requires a reference to the process that will be read.  
        /// The process should have .RedirectStandardOutput and .RedirectStandardError set to true.  
        /// </summary>  
        /// <param name="process">The process that will have its output read by this class.</param>  
        public ProcessOutputHandler(Process process, BackgroundWorker worker)
        {
            _worker = worker;
            proc = process;
            IVsOutputWindow outputWindow =
            Package.GetGlobalService(typeof(SVsOutputWindow)) as IVsOutputWindow;
            Guid guidGeneral = Microsoft.VisualStudio.VSConstants.OutputWindowPaneGuid.GeneralPane_guid;
            int hr = outputWindow.CreatePane(guidGeneral, "Phone Visualizer", 1, 0);
            hr = outputWindow.GetPane(guidGeneral, out _pane);
            _pane.Activate();
            _pane.OutputString("Starting Ui State workers..");
            StdErr = "";
            StdOut = "";
            Debug.Assert(proc.StartInfo.RedirectStandardError, "RedirectStandardError must be true to use ProcessOutputHandler.");
            Debug.Assert(proc.StartInfo.RedirectStandardOutput, "RedirectStandardOut must be true to use ProcessOutputHandler.");
        }
        /// <summary>  
        /// This method starts reading the standard error stream from Process.  
        /// </summary>  
        public void ReadStdErr()
        {
            string line;
            while ((!proc.HasExited) && ((line = proc.StandardError.ReadLine()) != null))
            {
                StdErr += line;
                _pane.OutputString(line + "\n");
                // Here I could do something special if errors occur
            }
        }
        /// <summary>  
        /// This method starts reading the standard output sream from Process.  
        /// </summary>  
        public void ReadStdOut()
        {
            string line;
            while ((!proc.HasExited) && ((line = proc.StandardOutput.ReadLine()) != null))
            {
                StdOut += line;
                _pane.OutputString(line + "\n");
                if (_worker != null && line.Contains("Something I'm looking for"))
                {                            
                   _worker.ReportProgress(20, "Something worth mentioning happened");
                }
            }
        }
    }
