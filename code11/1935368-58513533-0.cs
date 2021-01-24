    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
         if (userIsAdmin)
         {
           button1.Enabled = true;
         }
      }
    }
