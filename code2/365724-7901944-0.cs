    public DataForm(System.Data.DataSet theData): this(new List<System.Data.DataSet>{theData}){}
      
    public DataForm(DataSet[] DataArray): this(DataArray.ToList()){}
    
    public DataForm( List<System.Data.DataSet> DataList )
    {
        InitializeComponent();
    
        // Assign the list of datasets to teh member variable
        this.m_DSList = DataList;
    
        CreateTabPages();
    }
