    <#@ template debug="true" hostSpecific="true" #>
    <#@ output extension=".generated.cs" #>
    <#@ Assembly Name="System.Data" #>
    <#@ import namespace="System.Data" #>
    <#@ import namespace="System.Data.SqlClient" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="System.Text.RegularExpressions" #>
    <#  
    	string tableName = Path.GetFileNameWithoutExtension(Host.TemplateFile);
    	string path = Path.GetDirectoryName(Host.TemplateFile);
    	string columnId = "ID";
    	string columnName = "NAME";
    	string connectionString = "[your connection string]";
    #>
    using System; 
    using System.CodeDom.Compiler;  
    
    namespace Your.NameSpace.Enums
    {     
    	/// <summary>
    	/// <#= tableName #> auto generated enumeration
    	/// </summary>
    	[GeneratedCode("TextTemplatingFileGenerator", "10")]
    	public enum <#= tableName #>
    	{ 
    <#
    	SqlConnection conn = new SqlConnection(connectionString);
    	string command = string.Format("select {0}, {1} from {2} order by {0}", columnId, columnName, tableName);
    	SqlCommand comm = new SqlCommand(command, conn);
    	
    	conn.Open();
    	
    	SqlDataReader reader = comm.ExecuteReader();
    	bool loop = reader.Read(); 
    	
    	while(loop)
    	{ 
    #>
    		/// <summary>
    		/// <#= reader[columnName] #> configuration setting.
    		/// </summary>
    		<#= reader[columnName] #> = <#= reader[columnId] #><# loop = reader.Read(); #><#= loop ? ",\r\n" : string.Empty #> 
    <#  } 
    #>  }
    } 
    <#+     private string Pascalize(object value)
    		{
    			Regex rx = new Regex(@"(?:^|[^a-zA-Z]+)(?<first>[a-zA-Z])(?<reminder>[a-zA-Z0-9]+)");
    			return rx.Replace(value.ToString(), m => m.Groups["first"].ToString().ToUpper() + m.Groups["reminder"].ToString().ToLower());
    		}      
    		
    		private string GetSubNamespace()
    		{
    			Regex rx = new Regex(@"(?:.+Services\s)");
    			string path = Path.GetDirectoryName(Host.TemplateFile);
    			return rx.Replace(path, string.Empty).Replace("\\", ".");
    		}
    #>
