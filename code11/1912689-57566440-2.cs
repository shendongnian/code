    namespace CustomBinding
    {
        public class WebJobsStartup : IWebJobsStartup
        {
            void IWebJobsStartup.Configure(IWebJobsBuilder builder)
            {
                Debug.WriteLine("WebJobsStartup.Configure");
            }
        }
    }
