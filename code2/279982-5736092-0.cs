    private List<TestClass> columns = new List<TestClass>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public List<TestClass> Columns 
    { 
            get { return columns; } 
            set { columns = value; }
    }
