        static void Main(string[] args)
        {
            WebClient cli = new WebClient();
            cli.DownloadStringCompleted += (sender, e) => Console.WriteLine(e.Result);
            cli.DownloadStringAsync(new Uri("http://www.weather.gov")); // Blocks until request has been prepared
            
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }
