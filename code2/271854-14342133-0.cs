    [Column]
    [DataMember]
    public int? MonitoredDirectorySubCategoryID { set; get; }
    
    [NonSerialized]
    [XmlIgnore]
    [IgnoreDataMember]
    private EntityRef<BasicReference> _MonitoredDirectorySubCategory = new EntityRef<BasicReference>();
    
    [XmlIgnore]
    [IgnoreDataMember]
    [Association(Name = "FK_FilRef_BasRef_MonitoredDirectorySubCategoryID", IsForeignKey = true, Storage = "_MonitoredDirectorySubCategory", ThisKey = "MonitoredDirectorySubCategoryID")]
    public BasicReference MonitoredDirectorySubCategory 
    { set { _MonitoredDirectorySubCategory.Entity = value; } get { return _MonitoredDirectorySubCategory.Entity; } }
