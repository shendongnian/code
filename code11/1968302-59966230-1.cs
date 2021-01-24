`csharp
public class ExceptionTelemetryFilter : ITelemetryProcessor
    {
        private readonly ITelemetryProcessor _next;
        public ExceptionTelemetryFilter(ITelemetryProcessor next)
        {
            _next = next;
        }
        /// <summary>
        /// Exclude SocketException from logging
        /// </summary>
        /// <param name="item"></param>
        public void Process(ITelemetry item)
        {
            if(!(item is ExceptionTelemetry exception)  // If it is not an exception
               || !(exception.Exception is SocketException)) // or it is not a SocketException
                _next.Process(item); // then log the item by sending it down the processing pipeline
        }
    }
`
The take away is that, if you want to exclude an item from logging, you should *not* call `_next.Process(item)`.
Now, include it in the services collection so it is known by Application Insights. For .Net Core this is done like this:
`csharp
public void ConfigureServices(IServiceCollection services)
        {
            ...
            services.AddApplicationInsightsTelemetry();
            services.AddApplicationInsightsTelemetryProcessor<ExceptionTelemetryFilter>();
            
            ...
        }
`
Note: how to register the processor is determined by the kind of app. See the linked documentation on top for the options.
