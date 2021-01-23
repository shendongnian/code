    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        if (e.CommandName == "cmdFlag")
          {
            con.Open();
            cmd = new SqlCommand("UPDATE Comments SET Flagged = 'Yes' WHERE Comment_ID = @Comment_ID", con);
            cmd.Parameters.AddWithValue("@Comment_ID",e.CommandArgument);
            cmd.ExecuteNonQuery();
            Response.Redirect("~/renteronly/flagset.aspx");
          }
       }
