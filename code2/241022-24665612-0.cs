        public class IisExpressAgent
    {
        public void Start(string arguments)
        {
            ProcessStartInfo info= new ProcessStartInfo(@"C:\Program Files (x86)\IIS Express\iisexpress.exe", arguments)
            {
              // WindowStyle= ProcessWindowStyle.Minimized,
            };
            process = Process.Start(info);
        }
        Process  process;
        public void Stop()
        {
            process.Kill();
        }
    }
