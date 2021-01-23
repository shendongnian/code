    // create/open connection
    using (SqlConnection conn = new SqlConnection("Data Source=Si-6\\SQLSERVER2005;Initial Catalog=rags;Integrated Security=SSPI")
    {
        try
        {
            oCn.Open();
            // initialize command
            using (SqlCommand cmd = conn.CreateCommand())
            {
                // generate query with parameters
                with cmd
                {
                    .CommandType = CommandType.Text;
                    .CommandText = "insert into time(project,iteration) values(@name, @iteration)";
                    .Parameters.Add(new SqlParameter("@name", this.name1.SelectedValue));
                    .Parameters.Add(new SqlParameter("@iteration", this.iteration.SelectedValue));
                    .ExecuteNonQuery();
                }
            }
        }
        catch (Exception)
        {
            //throw;
        }
        finally
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close;
            }
        }
    }
