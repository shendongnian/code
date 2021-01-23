    public partial class MainWindow : Window
    {
        const string Path = @"C:\Windows\system32\sort.exe";
        BackgroundWorker Processer = new BackgroundWorker();
        public MainWindow()
        {
            InitializeComponent();
            Processer.WorkerReportsProgress = true;
            Processer.WorkerSupportsCancellation = true;
            Processer.ProgressChanged += Processer_ProgressChanged;
            Processer.DoWork += Processer_DoWork;
        }
        private void Processer_DoWork(object sender, DoWorkEventArgs e)
        {
            StreamReader StandardOutput = e.Argument as StreamReader;
            string data = StandardOutput.ReadLine();
            while (data != null)
            {
                Processer.ReportProgress(0, data);
                data = StandardOutput.ReadLine();
            }
        }
        private void Processer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string data = e.UserState as string;
            if (data != null)
                DataBox.Text += data + "\r\n";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataBox.Text = string.Empty;
            ProcessStartInfo StartInfo = new ProcessStartInfo(Path);
            StartInfo.RedirectStandardOutput = true;
            StartInfo.RedirectStandardInput = true;
            StartInfo.UseShellExecute = false;
            Process p = null;
            try { p = Process.Start(StartInfo); }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting {Path}: {ex.Message}");
                return;
            }
            // Get the output
            Processer.RunWorkerAsync(p.StandardOutput);
            // Put the input
            p.StandardInput.WriteLine("John");
            p.StandardInput.WriteLine("Alice");
            p.StandardInput.WriteLine("Zoe");
            p.StandardInput.WriteLine("Bob");
            p.StandardInput.WriteLine("Mary");
            // Tell the program that is the last of the data
            p.StandardInput.Close();
        }
    }
