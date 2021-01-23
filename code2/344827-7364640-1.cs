    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        RadioButton radio = e.Row.FindControl("RadioButton1") as RadioButton;
        if (radio != null)
        {
            radio.Visible = (bool)GridView1.DataKeys[e.Row.RowIndex]["SomeBooleanValue"];
        }
    }
