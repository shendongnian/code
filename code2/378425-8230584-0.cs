    public string ConnectionString
    {
        get
        {
            //Reading connection string from web.config
            return ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString;
        }
    }
    public bool InsertEmployee()
    {
        bool isSaved = false;
        int numberOfRowsAffected = 0;
        string query = @"INSERT INTO Employee(EmployeeName, EmailAddress)
                            VALUES (@EmployeeName, @EmailAddress);
                            SELECT @@IDENTITY AS RowEffected";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = query;
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.Parameters.Add(new SqlParameter("@EmployeeName", txtEmployeeName.Text));
        cmd.Parameters.Add(new SqlParameter("@EmailAddress", txtEmailAddress.Text));
        try
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cmd.Connection = cn;
                cn.Open();
                object result = cmd.ExecuteScalar();
                isSaved = Convert.ToInt32(result) > 0 ? true : false;
            }
        }
        catch (Exception ex)
        {
            isSaved = false;
        }
        return isSaved;
    }
