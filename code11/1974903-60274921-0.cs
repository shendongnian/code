    public class TelemetryEnrichment : TelemetryInitializerBase
    {
        public TelemetryEnrichment(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
    
        protected override void OnInitializeTelemetry(HttpContext platformContext, RequestTelemetry requestTelemetry, ITelemetry telemetry)
        {
            telemetry.Context.User.AuthenticatedUserId =
                platformContext.User?.Identity.Name ?? string.Empty;
        }
    }
