    public abstract class ErrorNotifier
    {
        string _processName;
        string _administratorEmail;
        public ErrorNotifier(string processName, string administratorEmail)
        {
            _processName = processName;
            _administratorEmail = administratorEmail;
        }
        public abstract void RunProcess();
        public void Run()
        {
            try
            {
                RunProcess();
            }
            catch (Exception ex)
            {
                SendErrorMessage(ex);
            }
        }
    }
