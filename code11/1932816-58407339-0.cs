    protected void YourGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label Label5 = (Label)e.Row.FindControl("Label5");
            if (int.Parse(Label5.Text) <= 10)
            {
                Label5.BackColor = System.Drawing.Color.LightPink;
            }
        }
    }
