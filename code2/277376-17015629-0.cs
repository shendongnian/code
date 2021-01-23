        public interface IWebClient
        {
            string DownloadString(string url);
        }
        public class WebClient : IWebClient
        {
            private readonly System.Net.WebClient _webClient = new System.Net.WebClient();
            public string DownloadString(string url)
            {
                return _webClient.DownloadString(url);
            }
        }
