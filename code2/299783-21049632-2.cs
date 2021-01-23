    public static bool GetIsJsonRequest(HttpRequestBase request)
    {
        if (request == null)
        {
            throw new ArgumentNullException("request");
        }
        bool rtn = false;
        const string jsonMime = "application/json";
        if (request.AcceptTypes!=null)
        {
            rtn = request.AcceptTypes.Any(t => t.Equals(jsonMime, StringComparison.OrdinalIgnoreCase));
        }
        return rtn || request.ContentType.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries).Any(t => t.Equals(jsonMime, StringComparison.OrdinalIgnoreCase));
    }
