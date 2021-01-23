    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        MySqlCommand cmd;
        string id1 = GridView1.DataKeys[e.RowIndex].Value.ToString();
        con.Open();
        cmd = new MySqlCommand("delete from tableName where refno='" + id1 + "'", con);
        cmd.ExecuteNonQuery();
        con.Close();
        BindView();
    }
    private void BindView()
    {
        GridView1.DataSource = ms.dTable("select * from table_name");
        GridView1.DataBind();
    }
