    public static class JsonResultController
    {
        public static bool IsJsonRequest(this HttpRequestBase request)
        {
            return GetIsJsonRequest(request);
        }
        public static bool IsJsonRequest(this HttpRequest request)
        {
            return GetIsJsonRequest(request);
        }
        private static bool GetIsJsonRequest(dynamic request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            bool rtn = false;
            const string jsonMime = "application/json";
            if (request.AcceptTypes != null)
            {
                rtn = (request.AcceptTypes as string[]).Any(t => t.Equals(jsonMime, StringComparison.OrdinalIgnoreCase));
            }
            return rtn || (request.ContentType as string ?? "").Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Any(t => t.Equals(jsonMime, StringComparison.OrdinalIgnoreCase));
        }
    }
