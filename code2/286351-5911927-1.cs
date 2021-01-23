    public class CustomCommands
    {
        private readonly static DelegateCommand admin;
        static CustomCommands()
        {
            admin = new DelegateCommand();
        }
        public static DelegateCommand AdminCommand
        {
            get { return admin; }
        }
    }
