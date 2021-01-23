    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells[8].Text.Equals("TextToMatch"))
        {
            e.Row.BackColor = System.Drawing.Color.DarkRed;
            e.Row.ForeColor = System.Drawing.Color.White;
        }
    }
