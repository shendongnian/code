    private string mName;
    //Some of my property
    public string Name
    {
        get { return this.mName }
        set
        {
            this.mName = value;
            this.onUpdate();
        }
    }
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? DatumPromjene { get; set; }
    public void onUpdate()
    {
        this.DatumPromjene = DateTime.Now;
    }
