    class MessageData
    {
        public string CorrelationId { get; set; }
        public string RequestForAPI { get; set; }
        public string RequestedSchemas { get; set; }
        public string Caller { get; set; }
        public string TennantId { get; set; }
        public static MessageData Parse(string input)
        {
            return new MessageData
            {
                CorrelationId = GetValueBetween(input, "CorrelationId:", "Request for API:"),
                RequestForAPI = GetValueBetween(input, "Request for API:", "Caller:"),
                Caller = GetValueBetween(input, "Caller:", "CorrelationId:"),
                RequestedSchemas = GetValueBetween(input, "RequestedSchemas:", "TenantId:"),
                TennantId = GetValueBetween(input, "TenantId:", null),
            };
        }
        private static string GetValueBetween(string input, string startDelim, string endDelim)
        {
            if (input == null) return string.Empty;
            var start = input.IndexOf(startDelim);
            if (start == -1) return string.Empty;
            start += startDelim.Length;
            var length = endDelim == null 
                ? input.Length - start 
                : input.IndexOf(endDelim, start) - start;
            if (length < 0) length = input.Length - start;
            return input.Substring(start, length).Trim();           
        }
    }
