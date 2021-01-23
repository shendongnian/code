    public ISolrQuery BuildQuery(string[] SearchFields, string SearchText)
        {
            try
            {
                AbstractSolrQuery firstQuery = new SolrQueryByField(parameters.SearchFields[0], parameters.SearchText) { Quoted = false };
                for (var i = 1; i < parameters.SearchFields.Length; i++)
                {
                    firstQuery = firstQuery || new SolrQueryByField(SearchFields[i], SearchText) { Quoted = false };
                }
                return firstQuery;
            }
