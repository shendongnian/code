    public class SynonymFilter : TokenFilter
    {
        public ISynonymEngine SynonymEngine { get; private set; }       
        private Queue<string> splittedQueue = new Queue<string>();        
        private readonly ITermAttribute _termAttr;
        private readonly IPositionIncrementAttribute _posAttr;
        private readonly ITypeAttribute _typeAttr;
        private State currentState;
        public SynonymFilter(TokenStream input, ISynonymEngine synonymEngine)
            : base(input)
        {
            if (synonymEngine == null)
                throw new ArgumentNullException("synonymEngine");
            SynonymEngine = synonymEngine;
            _termAttr = AddAttribute<ITermAttribute>();
            _posAttr = AddAttribute<IPositionIncrementAttribute>();
            _typeAttr = AddAttribute<ITypeAttribute>();
        }
        public override bool IncrementToken()
        {
            if (splittedQueue.Count > 0)
            {
                string splitted = splittedQueue.Dequeue();
                RestoreState(currentState);
                _termAttr.SetTermBuffer(splitted);
                _posAttr.PositionIncrement = 0;
                return true;
            }
            if (!input.IncrementToken())
                return false;
            var currentTerm = new string(_termAttr.TermBuffer(), 0, _termAttr.TermLength());            
            IEnumerable<string> synonyms = SynonymEngine.GetSynonyms(currentTerm);
            
            if (synonyms == null)
            {
                return false;
            }        
            foreach (string syn in synonyms)
            {                
                if (!currentTerm.Equals(syn))
                {
                    splittedQueue.Enqueue(syn);
                }
            }            
            return true;
        }
    }
