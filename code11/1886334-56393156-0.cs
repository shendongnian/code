DataTable database = new DataTable();
string dbString = ConfigurationManager.ConnectionStrings["YourConnection"].ConnectionString;
using (SqlConnection con = new SqlConnection(dbString))
using (SqlCommand cmd = new SqlCommand("dbo.YourSP", con))
{
    using(DataModel db = new DataModel())
    {
        cmd.CommandType = CommandType.StoredProcedure;
        
        cmd.Parameters.AddWithValue("@AccNo", AccNo);
        cmd.Parameters.AddWithValue("@DateFrom", DateFrom);
        cmd.Parameters.AddWithValue("@DateTo", DateTo);
        
        con.Open();
        cmd.ExecuteNonQuery();               
    }
}
This link is how you created a ConnectionString  for `YourConnection`: https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/creating-a-connection-string
