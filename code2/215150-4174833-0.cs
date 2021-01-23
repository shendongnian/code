    public static async Task AsynchronousCallServerMordernParallelAsync()
        {
            List<Task<string>> lstTasks = new List<Task<string>>();
            StringBuilder builder = new StringBuilder();
            for (int i = 2; i <= 10; i++)
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        Console.WriteLine("Calling server...");
                        Task<string> task = client.DownloadStringTaskAsync(new Uri("http://www.msn.com"));
                        lstTasks.Add(task);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error occurred!");
                    }
                }
            }
            string[] rss = await TaskEx.WhenAll<string>(lstTasks);
            foreach (string s in rss)
                builder.Append(s);
            Console.WriteLine("Downloaded!");
        }
