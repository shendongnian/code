    RAMDirectory dir = new RAMDirectory();
    IndexWriter writer = new IndexWriter(dir, new WhitespaceAnalyzer(), true);
    for (int i = 0; i < 20; i++)
    {
        Document doc = new Document();
        doc.Add(new Field("field1", "some text " + i.ToString(), Field.Store.YES, Field.Index.ANALYZED));
        doc.Add(new Field("ID", i.ToString(), Field.Store.YES, Field.Index.ANALYZED));
        writer.AddDocument(doc);
    }
    writer.Close();
    IndexReader reader = IndexReader.Open(dir);
    Lucene.Net.Search.Similar.MoreLikeThisQuery mltq = new Lucene.Net.Search.Similar.MoreLikeThisQuery("text", new string[] { "field1" }, new WhitespaceAnalyzer());
    BooleanQuery bq = new BooleanQuery();
    bq.Add(new MatchAllDocsQuery(), BooleanClause.Occur.MUST);
    bq.Add(new TermQuery(new Term("ID","15")),BooleanClause.Occur.MUST_NOT);
    Filter filter = new CachingWrapperFilter(new QueryWrapperFilter(bq));
            
    TopDocs td =  new IndexSearcher(reader).Search(mltq, filter, 100);
    Debug.Assert(td.TotalHits == 19);
    reader.Close();
