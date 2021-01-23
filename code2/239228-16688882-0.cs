    con.Open();
    for (int i = 0; i < GridView1.Rows.Count; i++)
     {
        String insertData = "INSERT INTO Land (Col1,Col2,Col3) VALUES (@Col1,@Col2,@Col3)";
        SqlCommand cmd = new SqlCommand(insertData, con);
        cmd.Parameters.AddWithValue("@Col1", GridView1.Rows[i].Cells[0].Text);
        cmd.Parameters.AddWithValue("@Col2", GridView1.Rows[i].Cells[1].Text);
        cmd.Parameters.AddWithValue("@Col3", GridView1.Rows[i].Cells[2].Text);
        cmd.ExecuteNonQuery();
     }
    con.Close();
