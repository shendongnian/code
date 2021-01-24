    using(SqlConnection conn = new SqlConnection(
        "Data Source=MININT-EP12N1V;Initial Catalog=EmployeeDB;Integrated Security=True"))
    {
    
        SqlCommand cmd = new SqlCommand("select FirstName, LastName from Employees");
        SqlDataReader reader = cmd.ExecuteReader();
        conn.Open();
        while (reader.Read())
        {
            Console.Write("{1}, {0}", reader.GetString(0), reader.GetString(1));
        }
        reader.Close();
        cmd.Dispose();
    }
