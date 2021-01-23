    protected void Page_Load(object sender, EventArgs e)
    {
        DebugButton btnDebug = new DebugButton();
        btnDebug.Click += new System.EventHandler(Button1_Click);
        PnlMain.Controls.Add(btnDebug);
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        // access whatever you want on the page here
    }
