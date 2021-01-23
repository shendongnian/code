    [DisplayName("Modified")]
    public DateTime Modified { get; set; }
    private string m_ModifiedBy
    [DisplayName("Modified By")]
    public string ModifiedBy { 
        get { return m_ModifiedBy; }
        set{ m_ModifiedBy = value; Modified = DateTime.Now; }
    }
