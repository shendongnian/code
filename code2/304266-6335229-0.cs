    public class ABC 
    {
        public ABC(int count)
        {
           if (count < 1) 
           {
               throw new ArgumentException("count must be a positive number", "count");
           }
            _textfillerDetails = Enumerable
                .Range(1, count)
                .Select(x => new TextDetail())
                .ToList();
        }
    
        public IList<TextFillerDetail> TextFillerDetails { get { return _textfillerDetails; } }        
        private List<TextFiller> _textfillerDetails;
    }
