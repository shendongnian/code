    public class ApiResponse<T> : IApiResponse<T>
    {
        [ScriptIgnore]
        public long QuotaRemaining { get; set; }
        [ScriptIgnore]
        public long QuotaMax { get; set; }
        public int Backoff { get; set; }
        public bool HasMore { get; set; }
    }
