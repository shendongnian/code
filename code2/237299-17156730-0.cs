    public class Messenger : IMessenger
    {
        private readonly IProcessWrapper _process;
        public Messenger(IProcessWrapper process)
        {
            _process = process;
        }
        public void SendMessage(string message)
        {
            var info = new ProcessStartInfo
                {
                    WorkingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "sysnative"),
                    FileName = "msg.exe",
                    Arguments = string.Format(@" * ""{0}""", message),
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = true,
                    Verb = "runas"
                };
            _process.Start(info);
        }
    }
    public interface IProcessWrapper : IDisposable
    {
        IEnumerable<Process> GetProcesses();
        void Start(ProcessStartInfo info);
        void Kill();
        bool HasExited { get; }
        int ExitCode { get; }
    }
