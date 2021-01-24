    [OperationContract]
            [WebGet(UriTemplate ="abc/{*value}")]
            string GetData(string value);
    
    
        public string GetData(string value)
                {
                    var result = System.Net.WebUtility.UrlDecode(value);
                    result = result.Replace("/", @"\\");
                    return result;
                }
