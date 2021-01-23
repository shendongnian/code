    protected void userclick_click(object sender, EventArgs e)
    {
        if(textbox1.Text == "2")
        {
            WebUserControl1 uc = (WebUserControl1) Page.LoadControl("WebUserControl1.ascx"); 
            PlaceHolder1.Controls.Add(uc); 
        }
        else
        {
          /*do nothing*/
        }
    }
