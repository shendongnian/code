 2. I make a generic SendAsync which can handle PUT/DELETE/POST/GET.
 3. I make ApiResponse class that contains the properties I'm interested in.
 4. I create a Request class (InitRequest) that I use for the request.
 5. I create a Response class (InitResponse) that I use for the response. 
 6. I have TimeOutInMs to set the time out for the api call. 
 7. I have a logger that logs error.
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Newtonsoft.Json;
    
    public class HomeController : Controller
    {
        private readonly WebApi _webApi;
        //Inject singleton httpclient and logger
        public HomeController(HttpClient httpClient, ILogger logger)
        {
            _webApi = new WebApi(httpClient, logger);
            _webApi.BaseAddress = "https://www.webapi.com/";
            _webApi.TimeOutInMs = 2000;
        }
    
        public async Task<ActionResult> Index()
        {
            //You might want to move the web api call to a service class
            var method = "init";
            var request = new InitRequest
            {
                Id = 1,
                Name = "Bob"
            };
    
            var response = await _webApi.SendAsync<InitResponse>(method, request, HttpMethod.Post);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var viewModel = response.Data.ToIndexViewModel();
            }
            else
            {
                //Handle Error
            }
    
            return View(viewModel);
        }
    }
    
    public class IndexViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
    
    public static class ModelMapper
    {
        public static IndexViewModel ToIndexViewModel(this InitResponse response)
        {
            return new IndexViewModel
            {
                Name = response.Name,
                Address = response.Address
            };
        }
    }
    
    public class InitRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class InitResponse
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
    
    public class WebApi
    {
    
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        public Uri BaseAddress { get; set; }
        public int TimeOutInMs { get; set; }
    
        public WebApi(HttpClient httpClient, ILogger logger)
        {
            _logger = logger ?? throw new Exception($"Missing constructor ceference - {nameof(logger)} can not be null!");
            _httpClient = httpClient ?? throw new Exception($"Missing constructor ceference - {nameof(httpClient)} can not be null!");
        }
    
        public async Task<ApiResponse<TOut>> SendAsync<TOut>(string method, object param, HttpMethod httpMethod)
        {
            if (string.IsNullOrWhiteSpace(BaseAddress.ToString()))
                throw new Exception($"{nameof(BaseAddress)} can not be null or empty.");
    
    
            if (string.IsNullOrWhiteSpace(method))
                throw new Exception($"{nameof(method)} can not be null or empty.");
    
            var paramListForLog = JsonConvert.SerializeObject(param);
    
            //Set timeout
            if (TimeOutInMs <= 0)
            {
                TimeOutInMs = (int)TimeSpan.FromSeconds(100.0).TotalMilliseconds;
            }
    
            var cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromMilliseconds(TimeOutInMs));
    
            var cancellationToken = cts.Token;
    
            var url = new Uri($"{BaseAddress}{method}", UriKind.Absolute);
    
            try
            {
    
                HttpResponseMessage response;
                using (var request = new HttpRequestMessage(httpMethod, url))
                {
                    //Add content
                    if (param != null)
                    {
                        var content = JsonConvert.SerializeObject(param);
                        request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                    }
                    //Add headers
                    request.Headers.Accept.Clear();
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                    _logger.Info($"Calling {httpMethod} for {url}", paramListForLog);
                    //Send the request
                    response = await _httpClient.SendAsync(request, cancellationToken);
                }
    
                //If success
                if (response.IsSuccessStatusCode)
                {
                    _logger.Info($"Successfully called {httpMethod} for {url}", paramListForLog);
                    var data = await response.Content.ReadAsAsync<TOut>(cancellationToken);
    
                    return new ApiResponse<TOut>
                    {
                        StatusCode = response.StatusCode,
                        Data = data
                    };
                }
    
                //If failure
                var error = await response.Content.ReadAsStringAsync();
                _logger.Error($"An error occured calling {httpMethod} for {url}. Error was {error}", paramListForLog);
                return new ApiResponse<TOut>
                {
                    StatusCode = response.StatusCode,
                    Message = error
                };
            }
            //If timeout
            catch (OperationCanceledException ex)
            {
                var message = cancellationToken.IsCancellationRequested ?
                    $"Request timed out after {TimeOutInMs} ms occured calling {httpMethod} for {url}. Error was: {ex.Message}" :
                    $"An error occured calling {httpMethod} for {url}. Error was: {ex.Message}";
    
                var webEx = new Exception(message, ex);
                _logger.Error(webEx, webEx.Message, paramListForLog);
    
                return new ApiResponse<TOut>
                {
                    StatusCode = HttpStatusCode.RequestTimeout,
                    Message = message
                };
            }
            //If unknown error
            catch (Exception ex)
            {
                var webEx = new Exception($"An error occured calling {httpMethod} for {url}. Error was: {ex.Message}", ex);
                _logger.Error(webEx, webEx.Message, paramListForLog);
                throw webEx;
            }
        }
    }
    public interface ILogger
    {
        void Info(string message, string param);
        void Error(string message, string param);
        void Error(Exception e, string message, string param);
    }
    
    public class ApiResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
  [1]: https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
  [2]: https://nodogmablog.bryanhogan.net/2017/10/reusing-httpclient-with-dependency-injection/
