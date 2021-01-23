    class Program
    {
        static void Main(string[] args)
        {
            RAMDirectory dir = new RAMDirectory();
            IndexWriter writer = new IndexWriter(dir, new StandardAnalyzer());
            AddDocument(writer, "John Doe", "NY");
            AddDocument(writer, "John Foo", "New Jersey");
            AddDocument(writer, "XYZ", "NY");
            writer.Commit();
            BooleanQuery query = new BooleanQuery();
            query.Add(new TermQuery(new Term("Name", "john")), BooleanClause.Occur.SHOULD);
            query.Add(new TermQuery(new Term("Location", "NY")), BooleanClause.Occur.SHOULD);
            IndexReader reader = writer.GetReader();
            IndexSearcher searcher = new IndexSearcher(reader);
            var hits = searcher.Search(query, null, 10);
            for (int i = 0; i < hits.totalHits; i++)
            {
                Document doc = searcher.Doc(hits.scoreDocs[i].doc);
                var explain = searcher.Explain(query, hits.scoreDocs[i].doc);
                Console.WriteLine("{0} - {1} - {2}", hits.scoreDocs[i].score, doc.ToString(), explain.ToString());
            }
        }
        private static void AddDocument(IndexWriter writer, string name, string address)
        {
            Document objDocument = new Document();
            Field objName = new Field("Name", name, Field.Store.YES, Field.Index.ANALYZED);
            Field objLocation = new Field("Location", address, Field.Store.YES, Field.Index.NOT_ANALYZED);
            objLocation.SetBoost(2f);
            objDocument.Add(objName);
            objDocument.Add(objLocation);
            writer.AddDocument(objDocument);
        }
    }
