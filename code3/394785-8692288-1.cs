    protected void userControlSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control c = null;
            if (userControlSelection.SelectedValue == "1")
            {
                c = this.LoadControl("~/WebUserControl1.ascx");
            }
            else if (userControlSelection.SelectedValue == "2")
            {
                c = this.LoadControl("~/WebUserControl2.ascx");                
            }
            if (c != null)
            {
                controlHolder.Controls.Clear();
                controlHolder.Controls.Add(c);
            }
            else
            {
                //Throw some error
            }
        }
