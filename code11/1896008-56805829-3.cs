    public partial class CHILD
    {
        public string PID_CHILD { get; set; }    
        public int ID { get; set; }
    	public int ID_PARENT { get; set; }
    	
    	[ForeignKey("ID_PARENT")]
    	public PARENT Parent {get;set;}
    }
    
    public partial class PARENT
    {
        public string ID_PARENT { get; set; }
        public List<CHILD> Childs { get; set; }
    }
