    private string _ModifiedBy;
 
    [DisplayName("Modified By")]
    public string ModifiedBy
    {
        get { return _ModifiedBy; }
        set { _ModifiedBy = value; Modified = DateTime.Now; }
    }
   
