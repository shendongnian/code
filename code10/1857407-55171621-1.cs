    class Program
    {
        // Create a static instance
        static readonly HttpClient HttpClient;
        
        public Program()
        {
            // Instaniate the static instance
            HttpClient = new HttpClient();
        }
        static void Main(string[] args) 
        {
            List<string> recordList = GetFromDatabase();
            Parallel.ForEach(recordList, (item) =>
            {
                // Add HttpClient to call
                item.Results = ProcessUsingExternalApi(item, HttpClient);
            }
            
            // Dispose of the static instance
            HttpClient.Dispose();
        }
        // Add an HttpClient argument
        static List<string> ProcessUsingExternalApi(string item, HttpClient httpClient)
        {
            try
            {
                // use httpClient here
            }
            catch(Exception)
            {
            }
        }
    }
