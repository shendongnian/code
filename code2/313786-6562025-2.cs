    public class TCmdChild : TCmdParent
    {
        public TYesNo FSgIsMale { get; set; }
        
        protected string fSgMrMs;
        public string FSgMrMs
        {
            get { return fSgMrMs; }
            set
            {
                if(value.Length > 2)
                    throw new OutOfRangeException("Value.Length needs to be <= 2");
                fSgMrMs = value;
            }
        }
    }
