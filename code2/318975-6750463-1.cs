    private Query CreateFilteredQuery (string account, string folder, Query criteria)
    {
         BooleanQuery bq = new BooleanQuery();
         bq.Add(new TermQuery (new Lucene.Net.Index.Term ("account", account)), BooleanClause.Occur.MUST);
         bq.Add(new TermQuery (new Lucene.Net.Index.Term ("folder", folder)), BooleanClause.Occur.MUST);
         bq.Add(criteria, BooleanClause.Occur.MUST);
         return bq;
    }
    Query filteredQuery = CreateFilteredQuery ("fake@fake.com", "inbox", myQueryParser.Parse (criteria));
    var hits = myIndexSearcher.Search (filteredQuery);
