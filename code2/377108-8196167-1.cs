    public class Section 
    { 
        public String Head
        {
            get
            {
                return SubHead.LastOrDefault();
            }
            set
            {
                SubHead.Add(value);
            }
     
        public List<string> SubHead { get; private set; }
        public List<string> Content { get; private set; }
    } 
