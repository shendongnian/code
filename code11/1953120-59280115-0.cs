    using (SqlConnection con = new SqlConnection(@"your connection string"))
    {
        con.Open();
        using(StreamReader file = new StreamReader(@"D:\Rutu\txtfile.txt"))
        {
             while((line = file.ReadLine()) != null)
             {
                 string[] fields = line.Split(',');
                 SqlCommand cmd = new SqlCommand("INSERT INTO employee_details(column1, column2, column3,column4) VALUES (@value1, @value2, @value3, @value4)", con);
                 cmd.Parameters.AddWithValue("@value1", fields[0].ToString());
                 cmd.Parameters.AddWithValue("@value2", fields[1].ToString());
                 cmd.Parameters.AddWithValue("@value3", fields[2].ToString());
                 cmd.Parameters.AddWithValue("@value4", fields[3].ToString());
                 cmd.ExecuteNonQuery();
             }
        }
     }
