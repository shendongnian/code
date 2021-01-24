    public class Uploader : IUploader
    {
        private readonly IHttpService _httpService; // made this a member variable
    
        public Uploader(IHttpService httpService) // dependency inject this
        {
            _httpService = httpService;
        }
    
        public async Task<string> Upload(string url, string data)
        {
            HttpResponseMessage result;
            try
            {
    
                result = await _httpService.PostAsync(new Uri(url), data);
    
                if (result.StatusCode != HttpStatusCode.OK)
                {
                    return "Some Error Message";
                }
                else
                {
                    return null; // Success!
                }
            }
            catch (Exception ex)
            {
                // do some fancy stuff here
            }
        }
    }
