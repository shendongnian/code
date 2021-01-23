        private DataTable ExecuteDynamic(string TableName,string FieldName, string Find)
        {
        
        string sqlSelect = "SELECT * FROM " + TableName +  
                            " WHERE " + FieldName + " LIKE '%'" + Find + "'%' ";
        using (connection = new SqlConnection(Strcon))
            connection.Open();
        {
            using (cmd = new SqlCommand(sqlSelect, connection))
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 60;
                adpt = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adpt.Fill(dt);
                return (dt);
            }
        }
    }
