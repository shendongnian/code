    protected void userclick_click(object sender, EventArgs e)
    {
        if(textbox1.Text == "2")
        {
            Control c1 = LoadControl("MyUserControl.ascx");
            //page or whatever control you want to add to
            Page.Controls.Add(c1);
        }
        else
        {
          /*do nothing*/
        }
    }
