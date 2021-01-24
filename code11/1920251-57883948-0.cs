        // Common interface with desired methods
        public interface IManager
        {
            void Manage();
        }
        public class BCMSDashboardManager : IManager
        {
            public void Manage()
            {
                Console.WriteLine("BCMSDashboardManager");
            }
        }
        public class SIPManager : IManager
        {
            public void Manage()
            {
                Console.WriteLine("SIPManager");
            }
        }
