    class QueryResult
    {
        // ...lots of other stuff...
    
        public QueryResult SetRequestUrl(string requestUrl)
        {
            QueryResult clone = this.Clone();
    
            // This property could have a private setter.
            clone.RequestUrl = requestUrl;
    
            return clone;
        }
    }
