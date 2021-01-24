            using Lucene.Net.Analysis.Standard;
            using Lucene.Net.Documents;
            using Lucene.Net.Index;
            using Lucene.Net.Search;
            using Lucene.Net.Store;
            using Lucene.Net.Util;            
            
            var AppLuceneVersion = LuceneVersion.LUCENE_48;
            var indexLocation = @"C:\Index";
            var dir = FSDirectory.Open(indexLocation);
            //create an analyzer to process the text
            var analyzer = new StandardAnalyzer(AppLuceneVersion);
            //create an index writer
            var indexConfig = new IndexWriterConfig(AppLuceneVersion, analyzer);
            var writer = new IndexWriter(dir, indexConfig);
