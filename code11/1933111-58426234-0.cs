    [XmlElement("WebWellConfiguration")]
    [SerializeField] private WebWellConfiguration _wellConfig;
    
    public WebWellConfiguration wellConfig 
    { 
        get { return _wellConfig; } 
        protected set { _wellConfig = value; }
    }
    
