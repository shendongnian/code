        public interface ILogger //public added
        {
            void Info(string message);
            void Error(string message);
        }
    
        public class Logger : ILogger
        {
            public void Error(string message)
            {
                Console.WriteLine($"Error: {message}");
            }
    
            public void Info(string message)
            {
                Console.WriteLine($"Info: {message}");
            }
        }
