    public partial class Start_deployment : Window
    {
        public Start_deployment()
        {
            InitializeComponent();
            Run_scripts();
        }
    
        public void Run_scripts()
        {
            var ps1File = @"C:\test\Install.ps1";
            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-ExecutionPolicy Bypass -WindowStyle Hidden -NoProfile -file \"{ps1File}\"",
                UseShellExecute = false
            };
            var proc = Process.Start(startInfo);
            proc.Exited += OnProcessExited;
        }
    
        private void OnProcessExited(object sender, EventArgs eventArgs)
        {            
            // todo, e.g.
            // System.Windows.Application.Current.Shutdown();
        }
    }
