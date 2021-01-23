    <#@ template debug="false" hostspecific="true" language="C#" #>
    <#@ output extension=".cs" #>
    <#@ template language="C#v3.5" #>
    <#@ output extension="CS" #>
    <#@ assembly name="System.Data.dll" #>
    <#@ assembly name="System.Xml.dll" #>
    <#@ import namespace="System.Data" #>
    <#@ import namespace="System.Data.SqlClient" #>
    <#
       string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Portal;User Id=sa;Password=33321a;";
    	DataTable tables = new DataTable("Tables");
    	using (SqlConnection connection =  new SqlConnection(connectionString))
    	{
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "select * from Rights order by name";
        connection.Open();
        tables.Load(command.ExecuteReader(CommandBehavior.CloseConnection));
    	}
       #>
    
    
    namespace <#Write(System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("NamespaceHint").ToString());#>
    {
    	public partial class RightsList
        {
    	<# foreach (DataRow row in tables.Rows){
    		string name = row["Name"].ToString();  
    		WriteLine("public string "+name+" { get; set; }");
    		}#> 
    	       
         }	
    	 
    	 	public enum Rights
        {
    	<# foreach (DataRow row in tables.Rows){
    		string name = row["Name"].ToString();  
    		WriteLine(name+", ");
    		}#> 
    	       
         }	  
    
    }
