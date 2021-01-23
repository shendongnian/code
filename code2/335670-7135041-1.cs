        static void Main() {
            var webClient = new WebClient();
            var currentPercentage = 0;
            webClient.DownloadProgressChanged += (s, args) => {
                if (currentPercentage < args.ProgressPercentage) {
                    Console.WriteLine(args.ProgressPercentage.ToString() + "%");
                }
                currentPercentage = args.ProgressPercentage;
            };
            webClient.DownloadSemiSync(new Uri("http://.."), "test");
        }
