    public static class HttpVerbsHelper
        {
            private static readonly Dictionary<HttpVerbs, string> Verbs =
                new Dictionary<HttpVerbs, string>()
                {
                    {HttpVerbs.Get, "GET"},
                    {HttpVerbs.Post, "POST"},
                    {HttpVerbs.Put, "PUT"},
                    {HttpVerbs.Delete, "DELETE"},
                    {HttpVerbs.Head, "HEAD"},
                    {HttpVerbs.Patch, "PATCH"},
                    {HttpVerbs.Options, "OPTIONS"}
                };
    
            public static HttpVerbs? GetVerb(string value)
            {
                var verb = (
                    from x in Verbs
                    where string.Compare(value, x.Value, StringComparison.OrdinalIgnoreCase) == 0
                    select x.Key);
                return verb.SingleOrDefault();
            }
        }
