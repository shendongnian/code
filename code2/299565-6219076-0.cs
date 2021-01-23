    using (SqlConnection conn = new SqlConnection("Server=(local);DataBase=Northwind;Integrated Security=SSPI")
    {
		
        SqlCommand cmd = new SqlCommand("SELECT Risk From HightAndWeightTable WHERE Hight LIKE '%" + @height + "%'", conn);
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@height";
        param.Value = domainUpDown1.Text;
        cmd.Parameters.Add(param);
        reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            //do something here:
            string risk = reader["Risk"];
        }
    }
