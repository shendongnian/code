                InitializeComponent();
                processes = Process.GetProcesses();
                List<processlist> processlist = new List<processlist>();
                foreach (Process item in processes)
                 {
                  processlist.Add(new processlist() { id = item.Id, name = item.ProcessName });
                 }
                ProcessInfo.ItemsSource = processlist;
