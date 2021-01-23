    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)     
    {
        if (e.Row.RowType == DataControlRowType.DataRow)         
        {
             // Get The button from which ever cell the button is in
             Button1.Click += new EventHandler(Button1_Click);
        }
    }
    void Button1_Click(object sender, EventArgs e)
    {
            
    }
