    string date = p_text_data.Text; 
    string sql = @"INSERT INTO Warehouse (title,count,price,date) "; 
    try 
    { 
        using (SqlConnection connection = ConnectToDataBase.GetConnection()) 
        { 
            SqlCommand command = new SqlCommand(sql, connection); 
            for (int i = 0; i < mdc.Count; i++) 
            { 
                sql += "SELECT @title" + i + ",@count" + i + ",@price" + i + ",@date" + i + " "; 
                command.Parameters.AddWithValue("@title" + i, mdc[i].Title); 
                command.Parameters.AddWithValue("@count" + i, mdc[i].Count); 
                command.Parameters.AddWithValue("@price" + i, mdc[i].Price); 
                command.Parameters.AddWithValue("@date" + i, Conver_Data(date)); 
                if (mdc.Count-1 != i) 
                    sql += "UNION ALL "; 
            } 
            sql += " ;"; 
            command.CommandText = sql;    //  Set your SQL Command to the whole statement.
            connection.Open();// *sql 
            command.ExecuteNonQuery();    //  Execute a query with no return value.
        } 
    } 
    catch (SqlException se) 
    { 
        MessageBox.Show(se.Message); 
    } 
