    public ISolrQuery GetFilterQueries()
    {
	    List<ISolrQuery> iSolrQueryList = new List<ISolrQuery>();
	    iSolrQueryList.Add(Query.Field("dr_success").Is("simple"));
   	    iSolrQueryList.Add(Query.Field("dr_success2").Is("simple2"));
        return new LocalParams { { "tag", "dt" } } + new SolrMultipleCriteriaQuery(iSolrQueryList, "OR");
    }
