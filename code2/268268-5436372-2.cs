	internal class IntegralCollector: Lucene.Net.Search.Collector {
		private int _docBase;
		private List<int> _docs = new List<int>();
		public List<int> Docs {
			get { return _docs; }
		}
		public override bool AcceptsDocsOutOfOrder() {
			return true;
		}
		public override void Collect( int doc ) {
			_docs.Add( _docBase + doc );
		}
		public override void SetNextReader( Lucene.Net.Index.IndexReader reader, int docBase ) {
			_docBase = docBase;
		}
		public override void SetScorer( Lucene.Net.Search.Scorer scorer ) {
		}
	}
