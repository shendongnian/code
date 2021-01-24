    [XmlElement("WebWellConfiguration")] 
    // [SerializeField] allows to mark private fields for serialization
    [SerializeField] private WebWellConfiguration _wellConfig;
    
    // since this is now no longer an auto-property but
    // using a backing field this one won't be serialized at all
    public WebWellConfiguration wellConfig 
    { 
        get { return _wellConfig; } 
        protected set { _wellConfig = value; }
    }
