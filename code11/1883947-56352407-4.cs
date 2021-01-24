    public interface IRetryHttpRequest {
        Task<HttpResponseMessage> ExecuteAsync(Func<HttpRequestMessage> requestMessage, HttpClient client, int maxTryValue);
    }
    public class LibraryService : ILibraryService {
        private IRetryHttpRequest _retryHttpRequest;
        public LibraryService(IRetryHttpRequest retryHttpRequest) {
            _retryHttpRequest = retryHttpRequest;
        }
        
        public async Task<ResponseModel> GetResponseForSearch(SearchRequest searchRequest, HttpClient client) {
            //send request and retry if failed
            ResponseModel result = new ResponseModel();
            HttpResponseMessage httpResponseMessage = await _retryHttpRequest.ExecuteAsync(() => new HttpRequestMessage(), client, 3);
            //process response
            if (httpResponseMessage != null) {
                string response = await httpResponseMessage.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ResponseModel>(response);
            }
            return result;
        }
    }
    public interface ILibraryService {
    }
    
