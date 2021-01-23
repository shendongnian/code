    struct tmpItems
    
    {
    
    //member variables
    
    private Int32 _ID;
    
    private String _Display;
    
    
    //properties
    
    public Int32 ID
    
    {
    
    get {return _ID;}
    
    }
    
    public String Display
    
    {
    
    get {return _Display;}
    
    }
    
    public tmpItems(Int32 pID , String pDisplay)
    
    {
    
    _ID = pID;
    
    _Display = pDisplay;
    
    } 
    
    }
    
    
    
    
    now assign
    
    ArrayList dataItems = new ArrayList();
    
    dataItems.Add(new tmpItems((int)dr[0], dr[1].ToString()));
    
    
    then finally 
    
    set 
    
    cbothis.DataSource = dataItems;
    
     cboThis.ValueMember = "ID";
    
     cboThis.DisplayMember = "Display";
