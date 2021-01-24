    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    // Define a list to store the row index of "COSC-1218-SIT41SCH"
    List<int> list = new List<int>();
    private void button1_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(@"Connection String"))
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * From GetCellTest", conn);
            sda.Fill(ds, "T_Class");
        }
        dt = ds.Tables["T_Class"];
        foreach (DataRow dr in dt.Rows)
        {
            if (dr["Level1"].ToString() == "COSC-1218-SIT41SCH")
            {
                list.Add(dt.Rows.IndexOf(dr));
            }
        }
        // Filter the first one
        list.Remove(0);
        // Get the value of "Cantidad"
        foreach(var i in list)
        {
            Console.WriteLine(dt.Rows[i]["Cantidad"].ToString());
        }
    }
