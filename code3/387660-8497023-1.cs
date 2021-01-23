    using System.Data.SqlClient;
    
    public partial class Default: System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection();
    
            connection.ConnectionString = "Data Source=localhost:8080;Initial Catalog=dbo.Table1;";
    connection.Open();
    
             dataadapter = new SqlDataAdapter("select * from customers", connection);
    
             lblLabel.Text = //something
    
         }
    }
