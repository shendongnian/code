    public class SynonymAnalyzer : Analyzer
    {
        public ISynonymEngine SynonymEngine { get; private set; }
        public SynonymAnalyzer(ISynonymEngine engine)
        {
            SynonymEngine = engine;
        }
        public override TokenStream TokenStream
		(string fieldName, System.IO.TextReader reader)
        {
            //create the tokenizer
            TokenStream result = new StandardTokenizer(reader);
            //add in filters
            // first normalize the StandardTokenizer
            result = new StandardFilter(result); 
            // makes sure everything is lower case
            result = new LowerCaseFilter(result);
            // use the default list of Stop Words, provided by the StopAnalyzer class.
            result = new StopFilter(result, StopAnalyzer.ENGLISH_STOP_WORDS); 
            // injects the synonyms. 
            result = new SynonymFilter(result, SynonymEngine); 
            //return the built token stream.
            return result;
        }
    }
