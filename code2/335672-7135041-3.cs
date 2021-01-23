        static void Main() {
            var webClient = new WebClient();
            webClient.DownloadProgressChanged += (s, args) => {..};
            webClient.DownloadSemiSync(new Uri("http://.."), "test.bin");
            Console.WriteLine("DownloadFinished");
        }
