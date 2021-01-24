    private void Page_Load()
    {
       if(Request.QueryString["switch"] !== null)
       {
            if(Request.QueryString["switch"].ToString()) == "on")
            {
                button.Visible = true;
                 ViewState["someval"] = hiddenVal.Text;
            }
            else
            {
                button.Visible = false;
            }
       }
    }
