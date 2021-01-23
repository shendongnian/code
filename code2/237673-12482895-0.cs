    public class PreserveStopWordsAnalyzer : StandardAnalyzer
    {
        public PreserveStopWordsAnalyzer() : base(Version.LUCENE_29, new Hashtable())
        {}
    }
