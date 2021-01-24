<connectionStrings>
  <add name="YOUR CONNECTION" connectionString="Data Source= ;Initial Catalog= ; User ID= ;Password= ;" providerName="System.Data.SqlClient" />
</connectionStrings>
//Connection to Web.config connectionStrings
DataTable database = new DataTable();
string dbString = ConfigurationManager.ConnectionStrings["YOUR CONNECTION"].ConnectionString;
using (SqlConnection con = new SqlConnection(dbString))
{
    try
    {
        //SQL query
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM sys.tables", con);
        adapter.Fill(database);
        //Populate ddlTable DropDownList
        ddlTable.DataSource = database;
        ddlTable.DataTextField = "name";
        ddlTable.DataValueField = "name";
        ddlTable.DataBind();
        ddlTable.Items.Insert(0, new ListItem("-- Select Table --", "0"));
    }
    catch (Exception)
    {
    }
}
