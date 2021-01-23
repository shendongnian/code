    protected void MyControl_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                var label = (Label)e.Row.FindControl("lblSkill1");
                if (label != null)
                    label.Text = "Text you want to set";
            }
        } 
