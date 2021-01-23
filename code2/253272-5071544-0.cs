    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
    DataTable dt3 = new DataTable(); // change to DataTable
    da3.Fill(dt3);
    conn.Close();
    if (dt3.Rows.Count > 0) {
        selectiteration.DataSource = dt3;
        selectiteration.DataTextField = "Iteration";
        selectiteration.DataValueField = "ProjectIterationID";
        selectiteration.DataBind();
    } else {
        selectiteration.Items.Add(
            new ListItem("You are not a member on this project.", 0));
    }
