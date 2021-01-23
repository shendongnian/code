    using System;
    using System.IO;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    class HttpSocket
    {
        private const int TimeoutLength = 100;
        public static void MakeRequest(Uri uri, Action<RequestCallbackState> responseCallback)
        {
            WebRequest request = WebRequest.Create(uri);
            request.Proxy = null;
            Task<WebResponse> asyncTask = Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);
            ThreadPool.RegisterWaitForSingleObject((asyncTask as IAsyncResult).AsyncWaitHandle, new WaitOrTimerCallback(TimeoutCallback), request, TimeoutLength, true);
            asyncTask.ContinueWith(task =>
                {
                    WebResponse response = task.Result;
                    Stream responseStream = response.GetResponseStream();
                    responseCallback(new RequestCallbackState(response.GetResponseStream()));
                    responseStream.Close();
                    response.Close();
                }, TaskContinuationOptions.NotOnFaulted);
            // Handle errors
            asyncTask.ContinueWith(task =>
                {
                    var exception = task.Exception;
                    var webException = exception.InnerException;
                
                    // Track whether you cancelled or not... up to you...
                    responseCallback(new RequestCallbackState(exception.InnerException, webException.Message.Contains("The request was canceled.")));
                }, TaskContinuationOptions.OnlyOnFaulted);
        }
        private static void TimeoutCallback(object state, bool timedOut)
        {
            Console.WriteLine("Timeout: " + timedOut);
            if (timedOut)
            {
                Console.WriteLine("Timeout");
                WebRequest request = (WebRequest)state;
                if (state != null)
                {
                    request.Abort();
                }
            }
        }
    }
    class RequestCallbackState
    {
        public Stream ResponseStream { get; private set; }
        public Exception Exception { get; private set; }
        public bool RequestTimedOut { get; private set; }
        public RequestCallbackState(Stream responseStream)
        {
            ResponseStream = responseStream;
        }
        public RequestCallbackState(Exception exception, bool timedOut = false)
        {
            Exception = exception;
            RequestTimedOut = timedOut;
        }
    }
    class RequestState
    {
        public byte[] RequestBytes { get; set; }
        public WebRequest Request { get; set; }
        public Action<RequestCallbackState> ResponseCallback { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Making a request to a nonexistent domain.
            HttpSocket.MakeRequest(new Uri("http://www.tanzaniatouristboard.com/"), callbackState =>
                {
                    if (callbackState.RequestTimedOut)
                    {
                        Console.WriteLine("Timed out!");
                    }
                    else if (callbackState.Exception != null)
                        throw callbackState.Exception;
                    else
                        Console.WriteLine(GetResponseText(callbackState.ResponseStream));
                });
            Thread.Sleep(100000);
        }
        public static string GetResponseText(Stream responseStream)
        {
            using (var reader = new StreamReader(responseStream))
            {
                return reader.ReadToEnd();
            }
        }
    }
