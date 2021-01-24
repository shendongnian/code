    public interface IRetryHttpRequest {
        Task<HttpResponseMessage> ExecuteAsync(Func<HttpRequestMessage> requestMessage, HttpClient client);
    }
    public class LibraryService : ILibraryService {
        private IRetryHttpRequest _retryHttpRequest;
        public LibraryService(IRetryHttpRequest retryHttpRequest) {
            _retryHttpRequest = retryHttpRequest;
        }
        public Task<HttpResponseMessage> GetResponse(Request request, HttpClient client) {
            return _retryHttpRequest.ExecuteAsync(() => request, client);
        }
    }
    public interface ILibraryService {
    }
    public class Request {
        public static implicit operator HttpRequestMessage(Request request) {
            //FOR DEMONSTRATIVE PURPOSES ONLY SO THE CODE COMPILES.
            var httpReqiest = new HttpRequestMessage();
            return httpReqiest;
        }
    }
    
