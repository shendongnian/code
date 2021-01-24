        public interface ICategoryService
        {
            string Output();
        }
        public class CategoryService : ICategoryService
        {
            public string Output()
            {
                return "CategoryService.Output";
            }
        }
        public interface ILoggingService
        {
            string Output();
        }
        public class LoggingService : ILoggingService
        {
            public string Output()
            {
                return "LoggingService.Output";
            }
        }
