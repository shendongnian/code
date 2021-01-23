    public void Page_Load(Object sender, EventArgs e)
    {
      if(!IsPostBack)
      {
        string onSubmit = userControl1.GetOnSubmitScript() + userControl2.GetOnSubmitScript();
        Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "get-html", onSubmit); 
      }
    }
