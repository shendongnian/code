        public interface ILogger //public added
        {
            void Info(string message);
            void Errorr(string message);
        }
    
        public class Logger : ILogger
        {
            public void Errorr(string message)
            {
                Console.WriteLine($"An error occured: {message}");
            }
    
            public void Info(string message)
            {
                Console.WriteLine($"Info: {message}");
            }
        }
