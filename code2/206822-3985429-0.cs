    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.From[Button1.UniqueID] != null)
        {
           // button1 click, handle it
           ...
        }
    }
