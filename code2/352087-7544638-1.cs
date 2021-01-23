    class Program
    {
        static void Main()
        {
            using (var client = new WebClient())
            {
                var result = client.DownloadString("http://example.com/test.aspx");
                File.WriteAllText("foo.txt", result);
            }
        }
    }
