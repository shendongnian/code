    public class RequestFilterResult
    {
        public static readonly RequestFilterResult Allow = new RequestFilterResult(true, null);
        public static RequestFilterResult Deny(string reason) { return new RequestFilterResult(false, reason); }
        protected RequestFilterResult(bool allowRequest, string denialReason)
        {
            AllowRequest = allowRequest;
            DenialReason = denialReason;
        }
        public bool AllowRequest { get; private set; }
        public string DenialReason { get; private set; }
    }
