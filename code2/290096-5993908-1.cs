    public class QueryResultBuilder
    {
        private string _requestUrl;
        // plus other fields
    
        public QueryResultBuilder SetRequestUrl(string requestUrl)
        {
            _requestUrl = requestUrl;
            return this;
        }
        // plus other methods
    
        public QueryResult Build()
        {
            // This could be an internal constructor,
            // only used by this builder type.
            return new QueryResult(_requestUrl /* plus other parameters *);
        }
    }
