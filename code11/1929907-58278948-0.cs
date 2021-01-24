    protected void Page_Load(object sender, EventArgs e)
    {
    
            if (ViewState["falg"] != null)
            {
                Create();
            }
    
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        Create();
        ViewState.Add("falg", true);
    }
    
    void BtnServices_Click(object sender, EventArgs e)
    {
        Response.Write("hi");
    }
    
    void BtnServices_Command(object sender, CommandEventArgs e)
    {
        Response.Write("hi");
    }
    void Create()
    {
        BtnServices = new Button();
        BtnServices.ID = "BtnServices";
        BtnServices.Text = "Click Me";
        BtnServices.Click += new EventHandler(BtnServices_Click);
        BtnServices.Command += new CommandEventHandler(BtnServices_Command);
        form1.Controls.Add(BtnServices);
    }
