    public class AdminControllerEventArgs : EventArgs
    {
        public bool Success;
        public AdminControllerEventArgs() : base()
        {
            Success = true;
        }
    }
