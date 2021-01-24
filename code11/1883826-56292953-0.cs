    public Process[] processes = Process.GetProcesses();
            public Form1()
            {
                InitializeComponent();
                foreach (Process process in processes)
                {
                    listView1.Items.Add("Process: {0} ID: { 1}  ", process.ProcessName, process.Id);
                }
            }
