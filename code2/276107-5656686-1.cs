    [ServiceContract]
    public class MdxService
    {
        const string JsonMimeType = "application/json";
        const string connectionString = "[Data Source String]";
        const string mdx = "[MDX query]";
        [OperationContract]
        [WebGet(UriTemplate = "OlapResults?session={session}&sequence={sequence}")]
        public Stream GetResults(string session, string sequence)
        {
            CellSet cellSet;
            using (AdomdConnection connection = new AdomdConnection(connectionString))
            {
                connection.Open();
                AdomdCommand command = connection.CreateCommand();
                command.CommandText = mdx;
                cellSet = command.ExecuteCellSet();
            }
            string result = JsonConvert.SerializeObject(cellSet, new CellSetConverter());
            WebOperationContext.Current.OutgoingResponse.ContentType = JsonMimeType;
            Encoding encoding = Encoding.UTF8;
            byte[] bytes = encoding.GetBytes(result);
            return new MemoryStream(bytes);
        }
    }
