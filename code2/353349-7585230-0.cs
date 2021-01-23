    public class ExecutableLauncher
    {
        private string _pathExe;
        public ExecutableLauncher(string pathExe)
        {
            _pathExe = pathExe;
        }
        public bool StartProcessAndWaitEnd(string argoment, bool useShellExecute)
        {
            try
            {
                Process currentProcess = new Process();
                currentProcess.EnableRaisingEvents = false;
                currentProcess.StartInfo.UseShellExecute = useShellExecute;
                currentProcess.StartInfo.FileName = _pathExe;
                // Es.: currentProcess.StartInfo.Arguments="http://www.microsoft.com";
                currentProcess.StartInfo.Arguments = argoment;
                currentProcess.Start();
                currentProcess.WaitForExit();
                currentProcess.Close();
                return true;
            }
            catch (Exception currentException)
            {
                throw currentException;
            }
        }
    }
