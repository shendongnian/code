    class Program
    {
        private static HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            var blobs = new List<Blob>();
            await ProcessBlobs(blobs);
            Console.ReadLine();
        }
        public static async Task ProcessBlobs(IEnumerable<Blob> blobs)
        {
            var tasks = blobs.Select(currentblob =>
            {
                string FileUrl = currentblob.Uri.ToString();
                string FileName = currentblob.Uri.Segments.Last();
                //string content = "{ \"fileUri\": \""+ currentblob.Uri.ToString()+ "\" , \"fileName\": \""+ currentblob.Uri.Segments.Last()+"\"}";
                Console.WriteLine(currentblob.Uri + " #### " + currentblob.Uri.Segments.Last());
                var values = new Dictionary<string, string>
                        {
                            { "fileUri", currentblob.Uri.ToString() },
                            { "fileName", currentblob.Uri.Segments.Last() }
                        };
                var content = new FormUrlEncodedContent(values);
                string baseURL = @"https://<afu>.azurewebsites.net/api/process_zip_files_by_http_trigger?code=45"; ;
                //string urlToInvoke = string.Format("{0}&name={1}", baseURL, FileUrl, FileName);
                return RunAsync(baseURL, content);
            });
            await Task.WhenAll(tasks);
        }
        public static async Task RunAsync(string i_URL, FormUrlEncodedContent content)
        {
            var response = await client.PostAsync(i_URL, content);
            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);
        }
    }
