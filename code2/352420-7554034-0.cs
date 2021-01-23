    protected void Page_Load(object sender, EventArgs e)
       {
          if (Request.QueryString["Name"] != null)
              Response.Write(Request.QueryString["Name"]);
    
                Int32 howmany = Int32.Parse(Request.QueryString["Name"]);
    
                for (int i = 1; i < howmany + 1; i++)
                {
                    TextBox tb = new TextBox();
                    tb.ID = "name" + i;
                    form1.Controls.Add(tb);
                }
        }
