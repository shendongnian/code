    [DataContract]
    public class Labels
    {
        private List<string> label;
    	
    	[DataMember]
        public List<string> labellist
        {
            get
            {
                return label;
            }
            set
            {
                label = value;
            }
        }
    }
