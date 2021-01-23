    class Program
        {
            static void Main(string[] args)
            {
                Demo d = new Demo();
                d.Process();
      
                Console.ReadLine();
            }
        }
    
        class Demo
        {
            public void Process()
            {
                List<string> urls = new List<string>() { "http://www.google.com", "http://www.bing.com", "http://www.cnn.com", "http://www.engadget.com" };
                foreach (var url in urls)
                {
                    WebClient Wc = new WebClient();
                    Wc.OpenReadCompleted += new OpenReadCompletedEventHandler(DownloadStringKmlCompleted);
                    Uri varUri = new Uri(url);
                    Wc.OpenReadAsync(varUri, url);
                }
            }
            void DownloadStringKmlCompleted(object sender, OpenReadCompletedEventArgs e)
            {
                StreamReader k = new StreamReader(e.Result);
                string temp = k.ReadToEnd();
                DoSomething(temp, e.UserState as string);
            }
    
             void DoSomething(string temp, string source)
            {
                Console.WriteLine(new string('*', 100));
                 Console.WriteLine("Source: {0}, Data: {1}", source, temp.Substring(0, 1000));
            }
        }
