        private const string HeaderProtoKey = "X-Forwarded-Proto";
        public static string GetRealScheme(this IOwinRequest request, bool skipPostfix = false)
        {
            if (request == null)
                return null;
            string headerProtocol = request.Headers[HeaderProtoKey] ?? string.Empty;
            string result = headerProtocol.ToLower().Contains("https")
                ? "https://"
                : request.Scheme;
            return skipPostfix
                ? result.Replace("://", string.Empty)
                : result;
        }
