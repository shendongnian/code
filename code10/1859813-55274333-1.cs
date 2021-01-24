    public form1()
    {
        InitializeComponent();
        this.radBtnFromAED.CheckedChanged += new System.EventHandler(this.radBtnFromUSD_CheckedChanged);
        this.radBtnFromAUD.CheckedChanged += new System.EventHandler(this.radBtnFromUSD_CheckedChanged);
        this.radBtnFromCAD.CheckedChanged += new System.EventHandler(this.radBtnFromUSD_CheckedChanged);
        this.radBtnFromEUR.CheckedChanged += new System.EventHandler(this.radBtnFromUSD_CheckedChanged);
        this.radBtnFromINR.CheckedChanged += new System.EventHandler(this.radBtnFromUSD_CheckedChanged);
        this.radBtnFromNZD.CheckedChanged += new System.EventHandler(this.radBtnFromUSD_CheckedChanged);
        this.radBtnFromRMB.CheckedChanged += new System.EventHandler(this.radBtnFromUSD_CheckedChanged);
        this.radBtnFromUSD.CheckedChanged += new System.EventHandler(this.radBtnFromUSD_CheckedChanged);
    }
