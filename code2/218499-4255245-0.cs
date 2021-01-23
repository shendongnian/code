    using System;
    using IndexReader = Lucene.Net.Index.IndexReader;
    namespace Lucene.Net.Search
    { 
    public abstract class RestrictedScoreDocCollector : TopDocsCollector
    {
        // Assumes docs are scored in order.
        private class InOrderTopScoreDocCollector : RestrictedScoreDocCollector
        {
            private Predicate<int> filter;
            private bool hasFilter = false;
            internal InOrderTopScoreDocCollector(int numHits, Predicate<int> filter)
                : base(numHits)
            {
                this.filter = filter;
                this.hasFilter = (filter != null);
            }
            public override void Collect(int doc)
            {
                if (this.hasFilter && !this.filter(doc))
                {
                    return;
                }
                float score = scorer.Score();
                // This collector cannot handle these scores:
                System.Diagnostics.Debug.Assert(score != float.NegativeInfinity);
                System.Diagnostics.Debug.Assert(!float.IsNaN(score));
                totalHits++;
                
                if (score <= pqTop.score)
                {
                    // Since docs are returned in-order (i.e., increasing doc Id), a document
                    // with equal score to pqTop.score cannot compete since HitQueue favors
                    // documents with lower doc Ids. Therefore reject those docs too.
                    return;
                }
                pqTop.doc = doc + docBase;
                pqTop.score = score;
                pqTop = (ScoreDoc)pq.UpdateTop();
            }
            public override bool AcceptsDocsOutOfOrder()
            {
                return false;
            }
        }
        // Assumes docs are scored out of order.
        private class OutOfOrderTopScoreDocCollector : RestrictedScoreDocCollector
        {
            private Predicate<int> filter;
            private bool hasFilter = false;
            internal OutOfOrderTopScoreDocCollector(int numHits, Predicate<int> filter)
                : base(numHits)
            {
                this.filter = filter;
                this.hasFilter = (filter != null);
            }
            public override void Collect(int doc)
            {
                if (this.hasFilter &&  !this.filter(doc))
                {
                    return;
                }
                float score = scorer.Score();
                // This collector cannot handle NaN
                System.Diagnostics.Debug.Assert(!float.IsNaN(score));
                totalHits++;
                doc += docBase;
                if (score < pqTop.score || (score == pqTop.score && doc > pqTop.doc))
                {
                    return;
                }
                pqTop.doc = doc;
                pqTop.score = score;
                pqTop = (ScoreDoc)pq.UpdateTop();
            }
            public override bool AcceptsDocsOutOfOrder()
            {
                return true;
            }
        }
        /// <summary> Creates a new {@link TopScoreDocCollector} given the number of hits to
        /// collect and whether documents are scored in order by the input
        /// {@link Scorer} to {@link #SetScorer(Scorer)}.
        /// 
        /// <p/><b>NOTE</b>: The instances returned by this method
        /// pre-allocate a full array of length
        /// <code>numHits</code>, and fill the array with sentinel
        /// objects.
        /// </summary>
        public static RestrictedScoreDocCollector create(int numHits, bool docsScoredInOrder,Predicate<int> filter)
        {
            if (docsScoredInOrder)
            {
                return new InOrderTopScoreDocCollector(numHits,filter);
            }
            else
            {
                return new OutOfOrderTopScoreDocCollector(numHits,filter);
            }
        }
        internal ScoreDoc pqTop;
        internal int docBase = 0;
        internal Scorer scorer;
        // prevents instantiation
        private RestrictedScoreDocCollector(int numHits)
            : base(new HitQueue(numHits, true))
        {
            // HitQueue implements getSentinelObject to return a ScoreDoc, so we know
            // that at this point top() is already initialized.
            pqTop = (ScoreDoc)pq.Top();
        }
        public /*protected internal*/ override TopDocs NewTopDocs(ScoreDoc[] results, int start)
        {
            if (results == null)
            {
                return EMPTY_TOPDOCS;
            }
            // We need to compute maxScore in order to set it in TopDocs. If start == 0,
            // it means the largest element is already in results, use its score as
            // maxScore. Otherwise pop everything else, until the largest element is
            // extracted and use its score as maxScore.
            float maxScore = System.Single.NaN;
            if (start == 0)
            {
                maxScore = results[0].score;
            }
            else
            {
                for (int i = pq.Size(); i > 1; i--)
                {
                    pq.Pop();
                }
                maxScore = ((ScoreDoc)pq.Pop()).score;
            }
            return new TopDocs(totalHits, results, maxScore);
        }
        public override void SetNextReader(IndexReader reader, int base_Renamed)
        {
            docBase = base_Renamed;
        }
        public override void SetScorer(Scorer scorer)
        {
            this.scorer = scorer;
        }
    }
}
