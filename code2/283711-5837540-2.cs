     public AsyncOperation DownloadYourDataObjects(Uri source, Action<IEnumerable<YourDataObject>> returnResult)
     {
         return (completed) =>
         {
             WebClient client = new WebClient();
             client.DownloadStringCompleted += (s, args) =>
             {
                 try
                 {
                     returnResult(ConvertStringToYourDataObjects(args.Result));
                     completed(null);
                 }
                 catch (Exception err)
                 {
                     completed(err);
                 }
             };
             client.DownloadStringAsync(source);
         };
     }
