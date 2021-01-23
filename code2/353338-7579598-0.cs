    class Program
    {
        static void Main()
        {
            using (var client = new WebClient())
            {
                client.DownloadFileCompleted += (sender, e) =>
                {
                    Console.WriteLine("finished");
                };
                client.DownloadFileAsync(new Uri("http://upload.wikimedia.org/wikipedia/en/d/d3/\"Baby\"_Palace_Hotel_1906.jpg"), "test.jpg");
                Console.ReadLine();
            }
        }
    }
