    // Shared interface
    public interface IFtpUtil
    {
        SomeFileObject GetFile(SomeArgument a);
        void PutFile(SomeFileObject f, SomeArgument a);
    }
    
    // Full framework implementation
    public class FullFtpUtil : IFtpUtil
    {
        public ... GetFile(...)
        {
            // Use System.Net classes from full framework
        }
    
        public ... PutFile(...)
        {
            // Use System.Net classes from full framework
        }
    }
    
    // Compact framework implementation
    public class CompactFtpUtil : IFtpUtil
    {
        public ... GetFile(...)
        {
            // Use your own FTP classes
        }
    
        public ... PutFile(...)
        {
            // Use your own FTP classes
        }
    }
