    public class Commander {
    
        private bool DoneReadingStdOut { get; set; }
    
        private bool DoneWaitingForPs { get; set; }
    
        public string ErrorMessage { get; set; }
    
        public bool IsFinished { get; set; }
    
        private Process Ps { get; set; }
    
        private ProcessPriorityClass m_PriorityClass = ProcessPriorityClass.Normal;
        public ProcessPriorityClass PriorityClass {
            get
            {
                return m_PriorityClass;
            }
            set
            {
                m_PriorityClass = value;
            }
        }
    
        private MemoryStream m_StdIn = null;
        public MemoryStream StandardInput
        {
            get { return m_StdIn; }
            set
            {
                m_StdIn = value;
                Ps.StartInfo.RedirectStandardInput = (value == null ? false : true);
            }
        }
    
        private MemoryStream m_StdOut = null;
        public MemoryStream StandardOutput
        {
            get { return m_StdOut; }
            set
            {
                m_StdOut = value;
                Ps.StartInfo.RedirectStandardOutput = (value == null ? false : true);
            }
        }
    
        private Timer m_Timer;  // To synchronize asynchronous activity
    
        public Commander(string command, string options)
        {
            m_Timer = new Timer();
            m_Timer.Enabled;
            m_Timer.Tick += timer_Tick;
            ErrorMessage = null;
            IsFinished = false;
            Ps = new Process();
            Ps.ErrorDataReceived += Ps_ErrorDataReceived;
            Ps.StartInfo.Arguments = options;
            Ps.StartInfo.CreateNoWindow = true;
            Ps.StartInfo.FileName = command;
            Ps.StartInfo.RedirectStandardError = true;
            Ps.StartInfo.WorkingDirectory = Path.GetDirectoryName(command); // optional
        }
    
        public event EventHandler<EventArgs> Finished;
        private void OnFinish(EventArgs e)
        {
            if (IsFinished) return;
            IsFinished = true;
            if (Finished != null)
            {
                Finished(this, e);
            }
        }
    
        public void Run()
        {
            Start();
        }
    
        public void Run(ref MemoryStream stdin, ref MemoryStream stdout)
        {
            StandardInput = stdin;
            StandardOutput = stdout;
            Start();
        }
    
        private void Start()
        {
            Ps.Start();
            Ps.PriorityClass = m_PriorityClass;
            Ps.BeginErrorReadLine();
            if (StandardInput != null)
            {
                Inject();
            }
            AsyncExtract();
            Ps.WaitForExit();
            DoneWaitingForPs = true;
        }
    
        private void Inject()
        {
            StandardInput.Position = 0;
            StandardInput.CopyTo(Ps.StandardInput.BaseStream);
            Ps.StandardInput.BaseStream.Close();
        }
    
        private byte[] m_StreamData = null;
        private int m_StreamDataLength = 8192;
        private void AsyncExtract()
        {
            if (m_StreamData == null)
            {
                m_StreamData = new byte[m_StreamDataLength];
            }
            Ps.StandardOutput.BaseStream.BeginRead(
                    m_StreamData, 0, m_StreamDataLength,
                    new AsyncCallBack(StandardOutput_AsyncCallBack),
                    null
                    );
        }
    
        private void StandardOutput_AsyncCallBack(IAsyncResult asyncResult)
        {
            int stdoutreadlength = Ps.StandardOutput.BaseStream.EndRead(asyncResult);
            if (stdoutreadlength == 0)
            {
                Ps.StandardOutput.BaseStream.Close();
                DoneReadingStdOut = true;
            }
            else
            {
                StandardOutput.Write(m_StreamData, 0, stdoutreadlength);
                AsyncExtract();
            }
        }
    
        private void Ps_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null) return;
            ErrorMessage += e.Data;
        }
    
        private timer_Tick(object sender, EventArgs e)
        {
            if (DoneWaitingForPs && DoneReadingStdOut)
            {
                m_Timer.Enabled = false;
                OnFinish(new EventArgs());
            }
        }
    }
