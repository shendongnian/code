        public class CustomAnalyzer : StandardAnalyzer
        {
            Lucene.Net.Util.Version matchVersion;
            public CustomAnalyzer(Lucene.Net.Util.Version p_matchVersion)
                : base(p_matchVersion)
            {
                matchVersion = p_matchVersion;
            }
            public override TokenStream TokenStream(string fieldName, System.IO.TextReader reader)
            {
                TokenStream result = new StandardTokenizer(matchVersion, reader);
                result = new StandardFilter(result);
                result = new ASCIIFoldingFilter(result);
                return result;
            }
        
        }
