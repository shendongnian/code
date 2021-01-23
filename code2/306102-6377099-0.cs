    class Program
    {
        static void Main()
        {
            var url = "http://downloads.sourceforge.net/project/junit/junit/3.8.1/junit3.8.1.zip";
            using (var client = new WebClient())
            using (var zip = ZipFile.Read(client.DownloadData(url)))
            {
                foreach (var entry in zip)
                {
                    entry.Extract(".");
                }        
            }
        }
    }
