    using System;
    using System.IO;
    using System.Net;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DownloadFile();
                Console.ReadLine();
            }
    
            public static void DownloadFile()
            {
                var downloadedDatabaseFile = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
                Console.WriteLine(downloadedDatabaseFile);
    
                var client = new WebClient();
                client.DownloadProgressChanged += (sender, args) =>
                {
                    Console.WriteLine("{0} of {1} {2}%", args.BytesReceived, args.TotalBytesToReceive, args.ProgressPercentage);
                };
    
                client.DownloadFileCompleted += (sender, args) =>
                {
                    Console.WriteLine("Download file complete");
    
                    if (args.Error != null)
                    {
                        Console.WriteLine(args.Error.Message);
                    }
                };
    
                client.DownloadFileAsync(new Uri("http://geolite.maxmind.com/download/geoip/database/GeoLiteCity.dats.gz"), downloadedDatabaseFile);
            }
        }
    }
