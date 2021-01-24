    class Program
    {
        private static readonly string ApiKey = System.Configuration.ConfigurationManager.AppSettings.Get("BingMapsKey");
        private static readonly AutoResetEvent StopWaitHandle = new AutoResetEvent(false);
        public static void Main()
        {
            var query = "1 Microsoft Way, Redmond, WA";
            BingMapsRESTToolkit.Location result = null;
            Uri geocodeRequest = new Uri(string.Format("http://dev.virtualearth.net/REST/v1/Locations?q={0}&key={1}",
                query, ApiKey));
            GetResponse(geocodeRequest, (x) =>
            {
               if (response != null &&
                  response.ResourceSets != null &&
                  response.ResourceSets.Length > 0 &&
                  response.ResourceSets[0].Resources != null &&
                  response.ResourceSets[0].Resources.Length > 0)
               {
                   result = response.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Location;
                }
            });
            StopWaitHandle.WaitOne(); //wait for callback
            Console.WriteLine(result.Point); //<-access result 
            Console.ReadLine();
        }
        private static void GetResponse(Uri uri, Action<Response> callback)
        {
            var wc = new WebClient();
            wc.OpenReadCompleted += (o, a) =>
            {
                if (callback != null)
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Response));
                    callback(ser.ReadObject(a.Result) as Response);
                }
                StopWaitHandle.Set(); //signal the wait handle
            };
            wc.OpenReadAsync(uri);
        }
    }
