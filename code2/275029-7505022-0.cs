        class TVM : TermVectorMapper
        {
            public List<string> FoundTerms = new List<string>();
            HashSet<string> _termTexts = new HashSet<string>();
            public TVM(Query q, IndexReader r) : base()
            {
                List<Term> allTerms = new List<Term>();
                q.Rewrite(r).ExtractTerms(allTerms);
                foreach (Term t in allTerms) _termTexts.Add(t.Text());
            }
            public override void SetExpectations(string field, int numTerms, bool storeOffsets, bool storePositions)
            {
            }
            public override void Map(string term, int frequency, TermVectorOffsetInfo[] offsets, int[] positions)
            {
                if (_termTexts.Contains(term)) FoundTerms.Add(term);
            }
        }
        void TermVectorMapperTest()
        {
            RAMDirectory dir = new RAMDirectory();
            IndexWriter writer = new IndexWriter(dir, new Lucene.Net.Analysis.Standard.StandardAnalyzer(), true);
            Document d = null;
            d = new Document();
            d.Add(new Field("text", "microscope aaa", Field.Store.YES, Field.Index.ANALYZED,Field.TermVector.WITH_POSITIONS_OFFSETS));
            writer.AddDocument(d);
            d = new Document();
            d.Add(new Field("text", "microsoft bbb", Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS));
            writer.AddDocument(d);
            writer.Close();
            IndexReader reader = IndexReader.Open(dir);
            IndexSearcher searcher = new IndexSearcher(reader);
            QueryParser queryParser = new QueryParser("text", new Lucene.Net.Analysis.Standard.StandardAnalyzer());
            queryParser.SetMultiTermRewriteMethod(MultiTermQuery.SCORING_BOOLEAN_QUERY_REWRITE); 
            Query query = queryParser.Parse("micro*");
            
            TopDocs results = searcher.Search(query, 5);
            System.Diagnostics.Debug.Assert(results.TotalHits == 2);
            
            TVM tvm = new TVM(query, reader);
            for (int i = 0; i < results.ScoreDocs.Length; i++)
            {
                Console.Write("DOCID:" + results.ScoreDocs[i].Doc + " > ");
                reader.GetTermFreqVector(results.ScoreDocs[i].Doc, "text", tvm);
                foreach (string term in tvm.FoundTerms) Console.Write(term + " ");
                tvm.FoundTerms.Clear();
                Console.WriteLine();
            }
        }
