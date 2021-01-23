    protected void page_load(object sender, EventArgs e)
    {
       if (!IsPostback)
       {
          var recordId = Response.QueryString["recordId"];
          if (!string.IsNullOrEmpty(recordId))
          {
             // update database
             ...
          }
       }
       ...
    }
