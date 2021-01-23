      public DataForm()
            {
                 InitializeComponent(); 
            }
            public DataForm(DataSet theData): this()
            {
                this.m_DSList= (theData!=null) ? new List<DataSet>{theData}:null;
            }
            public DataForm(DataSet[] DataArray):this()
            {
                 this.m_DSList= (DataArray!=null && DataArray.Length > 0) ? new List<DataSet>(DataArray):null;
            }
            public DataForm(List<DataSet> DataList ):this() 
            {           
                this.m_DSList = DataList; 
            }
            //Take this method out from constructor and for a better design but not mandatory
             public void CreateTabPages()
             {
             }
