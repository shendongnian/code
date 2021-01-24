    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var service = new Service();
            var apiCall = service.CallApi();
            apiCall.OnSuccess.OnNext += (_, __) => Console.WriteLine("Success!");
            apiCall.OnTimeout.OnNext += (_, __) => Console.WriteLine("Timeout!");
            Console.ReadLine();
        }
    }
    class SuccessEventArgs{}
    class TimeoutEventArgs{}
    class ApiCall
    {
        public IEventPatternSource<SuccessEventArgs> OnSuccess {get;}
        public IEventPatternSource<TimeoutEventArgs> OnTimeout {get;}
        public ApiCall(IEventPatternSource<SuccessEventArgs> onSuccess, IEventPatternSource<TimeoutEventArgs> onTimeout)
        {
            OnSuccess = onSuccess;
            OnTimeout = onTimeout;
        }
    }
    class Service
    {
        public ApiCall CallApi()
        {    
            var apiCall = Observable
                .Timer(TimeSpan.FromSeconds(3))
                .Do(_ => Console.WriteLine("Api Called"))
                .Select(_ => new EventPattern<SuccessEventArgs>(null, new SuccessEventArgs()))
                // .Timeout(TimeSpan.FromSeconds(2)) // uncomment to time out
                .Timeout(TimeSpan.FromSeconds(4))
                // the following two lines turn the "cold" observable "hot"
                // comment them out and see how often "Api Called" is logged
                .Publish()
                .RefCount();
                
            var success = apiCall
                // ignore the TimeoutException and return an empty observable
                .Catch<EventPattern<SuccessEventArgs>, TimeoutException>(_ => Observable.Empty<EventPattern<SuccessEventArgs>>())
                .ToEventPattern();
            
            var timeout = apiCall
                .Materialize() // turn the exception into a call to OnNext rather than OnError
                .Where(x => x.Exception is TimeoutException)
                .Select(_ => new EventPattern<TimeoutEventArgs>(null, new TimeoutEventArgs()))
                .ToEventPattern();
            return new ApiCall(success, timeout);
        }
    }
