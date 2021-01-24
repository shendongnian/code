    public class MyService() {
        private readonly HttpClient _client;
    
        public MyService() {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://test.com");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("JWT", "token");
        }
    
        public static async Task<IEnumerable<ResultDto>> PostDataParallelBatch() 
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var tasks = new List<Task<HttpResponseMessage>>();
            string strConnection = GetConnectionString("");
            string queryString = "select * from test.dbo.test_table";
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
    
                try
                {            
                    var batchSize = 200;
                    var currentIdx = 0;
                    while (reader.Read())
                    {
                        var batchFinished = currentIdx % batchSize == 0;
                        var metaDataTask = runMetadataAPI(reader, batchFinished);
                        tasks.Add(metaDataTask);
                        currentIdx++;
                    }
    
                }
                catch (Exception e)
                {
                    ExceptionHandler(e);
                }
                finally
                {
                    reader.Close();
                    connection.Close();
                }
            }
            await Task.WhenAll(tasks);
            watch.Stop();
        }
    
        private static async Task<HttpResponseMessage> runMetadataApi(SqlDataReader reader, bool batchFinished) {
            if(batchFinished) {
                await Task.Delay(60000);
            }
            string requestUri = "/api/metadata";
            var metaDataPostData = new MetaDataPostData();
            metaDataPostData.CId= reader["CId"].ToString();
            metaDataPostData.SId = "somevalue"; 
            Metadata[] metaData = new Metadata[1];
            metaData[0] = new Metadata();
            metaData[0].Key = "columnname";
            metaData[0].Value = "columnvalue";
            metaDataPostData.Metadata = metaData;
            var json = JsonConvert.SerializeObject(metaDataPostData);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return client.PostAsync(requestUri, data);
        }
    }
