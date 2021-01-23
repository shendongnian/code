    protected void Page_Load(object sender, EventArgs e){
    
    if(!this.isPostBack)
    {
      if(!Context.User.IsInRole("admin"))
      {
         //disable controls
      }
    }
    }
