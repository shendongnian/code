    public ISolrQuery BuildQuery(string[] SearchFields, string SearchText)
        {
            try
            {
                AbstractSolrQuery firstQuery = new SolrQueryByField(SearchFields[0], SearchText) { Quoted = false };
                for (var i = 1; i < parameters.SearchFields.Length; i++)
                {
                    firstQuery = firstQuery || new SolrQueryByField(SearchFields[i], SearchText) { Quoted = false };
                }
                return firstQuery;
            }
