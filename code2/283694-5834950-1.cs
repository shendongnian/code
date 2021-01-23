       static void Main(string[] args)
       {
           BackgroundWorker bg = new BackgroundWorker();
           bg.DoWork += backgroundWorker_DoWork;
    
           bg.RunWorkerAsync(new List<object> { "http://download.thinkbroadband.com/512MB.zip" });
           while (true) {}
       }
    
       private static void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
       {
           Console.WriteLine("Starting operation.");
           BackgroundWorker bw = sender as BackgroundWorker;
    
           List<object> args = (List<object>)e.Argument;
    
           var url = (string)args[0];
           WebRequest request = WebRequest.Create(url);
           request.Timeout = 300;
    
           try
           {
               WebResponse response = request.GetResponse();
               Console.WriteLine("Request successful.");
           }
           catch (Exception ex)
           {
               Console.WriteLine("Request timed out.");
           }
       }
