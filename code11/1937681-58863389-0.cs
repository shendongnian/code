internal class AbortedRequestTelemetryProcessor : ITelemetryProcessor
{
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly ITelemetryProcessor next;
    public AbortedRequestTelemetryProcessor(
        ITelemetryProcessor next, IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
        this.next = next;
    }
    public void Process(ITelemetry item)
    {
        if (httpContextAccessor.HttpContext?.RequestAborted.IsCancellationRequested == true 
            && item is ExceptionTelemetry)
        {
            // skip exception telemetry if cancellation was requested
            return; 
        }
        // Send everything else:
        next.Process(item);
    }
}
