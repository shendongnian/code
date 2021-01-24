    public class ApiOne: IApi
    {
        private IWebClient _client;
        public ApiOne(IWebClient client)
        {
            _client = client;
        }
    
        public CommonResponse GetData()
        {
            var response = _client.Get<ApiOneResponse>($"{some specific url for this api");
            return new CommonResponse
            {
                CommonFieldOne = response.FieldOne,
                CommonFieldTwo = response.FieldTwo
            }
        }
    }
