    protected void Page_Load(object sender, EventArgs e) {
      if (IsPostBack) return;
      var refDblClick = ClientScript.GetPostBackEventReference(lnkButton, "dblClick");
      lstActivities.Attributes.Add("ondblclick", refDblClick);
      
      ScriptManager1.RegisterAsyncPostBackControl(lstActivities);
    }
