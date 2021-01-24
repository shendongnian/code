    public class PasswordExpection : Exception
    {
        public PasswordExpection(string msg) : base(msg) { }
    }
    public class BiosExpection : Exception
    {
        public BiosExpection(string msg, Exception inner) : base(msg, inner) { }
    }
    interface IBiosControl
    {
        /// <summary>
        /// Checks if a password is set.
        /// </summary>
        /// <exception cref="PasswordExpection">if the concept of password does not apply</exception>
        /// <exception cref="BiosExpection">if there was an execution error</exception>
        /// <returns>Weather or not the password was set</returns>
        bool IsPasswordSet();
    }
    public class MyBios : IBiosControl
    {
        private readonly Action<string> _logger;
        public MyBios(Action<string> logger)
        {
            _logger = logger;
        }
        public bool IsPasswordSet()
        {
            try
            {
                _logger("MyBios IsPasswordSet Connecting To Bios...");
                throw new NotImplementedException();
            }
            catch(Exception e)
            {
                throw new BiosExpection("Execution Error", e);
            }
        }
    }
