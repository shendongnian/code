			var dir = SimpleFSDirectory.Open(new DirectoryInfo(IndexPath));
			var ixSearcher = new IndexSearcher(dir, false);
			var qp = new QueryParser(Lucene.Net.Util.Version.LUCENE_29, f_Text, analyzer);
			query = CleanQuery(query);
			Query q = qp.Parse(query);
			TopFieldCollector collector = TopFieldCollector.Create(
				  new Sort(new SortField(null, SortField.SCORE, false), new SortField(f_Date, SortField.LONG, true)),
				  MAX_RESULTS,
				  false,         // fillFields - not needed, we want score and doc only
				  true,          // trackDocScores - need doc and score fields
				  true,          // trackMaxScore - related to trackDocScores
				  false); // should docs be in docId order?
			ixSearcher.Search(q, collector);
			TopDocs topDocs = collector.TopDocs();
			ScoreDoc[] hits = topDocs.ScoreDocs;
			uint pageCount = (uint)Math.Ceiling((double)hits.Length / pageSize);
			for (uint i = pageIndex * pageSize; i < (pageIndex + 1) * pageSize; i++) {
				if (i >= hits.Length) {
					break;
				}
				int doc = hits[i].Doc;
				Content c = new Content {
					Title = ixSearcher.Doc(doc).GetField(f_Title).StringValue(),
					Text = FragmentOnOrgText(ixSearcher.Doc(doc).GetField(f_TextOrg).StringValue(), highligter.GetBestFragments(analyzer, ixSearcher.Doc(doc).GetField(f_Text).StringValue(), maxNumberOfFragments)),
					Date = DateTools.StringToDate(ixSearcher.Doc(doc).GetField(f_Date).StringValue()),
					Score = hits[i].Score
				};
				rv.Add(c);
			}
			ixSearcher.Close();
