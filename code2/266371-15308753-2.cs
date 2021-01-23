     protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
     {
        string fname, lname;
        fname = GridView1.Rows[e.NewEditIndex].Cells[0].Text;
        Session["fname"] = fname;
        lname = GridView1.Rows[e.NewEditIndex].Cells[1].Text;
        Session["lname"] = lname;
        Response.Redirect("gridpass.aspx");
     }
