    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Bind Grid, only on first load
        }
    }
    
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        Label1.Text = DateTime.Now.ToString();  //Set label
        UpdatePanel1.Update();  //Update only Label's update panel
    }
