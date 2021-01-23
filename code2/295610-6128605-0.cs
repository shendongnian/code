    using System.Threading;
       void Application_Start(object sender, EventArgs e)        
       {
            Thread VideoConversionThread = new System.Threading.Thread(new ThreadStart(VideoConversion));
            VideoConversionThread.Name = "VideoConversion";
            VideoConversionThread.IsBackground = true;
            VideoConversionThread.Start();
        }
        private void VideoConversion()
        {
            while (true)
            {
                //Get Count of records that need conversion.
                if(Count > 0)
                {
                     var records = //GetRecords from database that require conversion
                     foreach(var record in records)
                     {
                         //either spawn a seperate worker thread for each record or perform tasks here
                         //perform conversion
                         //update database to mark item as completed
                         //you could also start/stop the service from here
                     }
                 }
                 Thread.Sleep(5000); //sleep
             }
          }
