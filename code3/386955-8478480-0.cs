    class Program
    {
        static void Main(string[] args)
        {
            var task = CrawlAsync("http://stackoverflow.com");
            task.Wait();
        }
        static Task CrawlAsync(string url)
        {
            return Task.Factory.StartNew(
                () =>
                {
                    string[] children = ExtractChildren(url);
                    foreach (string child in children)
                    {
                        CrawlAsync(child);
                    }
                    ProcessUrl(url);
                }, TaskCreationOptions.AttachedToParent);
        }
        static string[] ExtractChildren(string root)
        {
          // Return all child urls here.
        }
        static void ProcessUrl(string url)
        {
          // Process the url here.
        }
    }
