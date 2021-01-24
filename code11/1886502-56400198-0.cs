    class Program
    {
        public static void Main(string[] args)
        {
            apiCall();
            Console.ReadKey();
        }
        public static void apiCall()
        {
            //client to invoke the car query api
            WebClient client = new WebClient();
            Task<String> carQueryTask = null;// Task<string> that queries carQuery
            
            // url for API (no key required)
            string url = "https://www.carqueryapi.com/api/0.3/?callback=?&cmd=getTrims&make=toyota&model=camry&year=2005";
            try
            {
                //request info from the api
                carQueryTask = client.DownloadStringTaskAsync(url);
                string result = carQueryTask.Result.Remove(0, 2);
                result = result.Remove(result.Length - 2, 2);
           
                dynamic json = JsonConvert.DeserializeObject(result);
                var model_name = json.Trims[0].model_name;
                Console.WriteLine(model_name);
               
            }
            catch (WebException)
            {
                // check whether Task failed
                if (carQueryTask.Status == TaskStatus.Faulted)
                {
                    Console.WriteLine("Call Failed");
                }
            }
        }
    }
}
``
