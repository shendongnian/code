    public DataTable getReportByDate(DateTime startDate, DateTime endDate)
    {
    DataTable table = new DataTable();
                string query = "select * from [transaction] where cast(currdate as date) >= @startdate and cast(currdate as date) <= @enddate";
                using (SqlConnection connection = new SqlConnection("server=(local);database=quicksilver;integrated security=true"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query);
                    command.Parameters.AddWithValue("@startdate", startdate);
                    command.Parameters.AddWithValue("@enddate", enddate);
                    command.Connection = connection;
    
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    //
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    dataAdapter.Fill(table); 
    
                }
    return table;
    }
