		<#@ template language="C#v3.5" hostspecific="true"#>
		<#@ output extension="cs" #>
		<#@ assembly name="System.Core" #>
		<#@ assembly name="System.Data" #>
		<#@ assembly name="System.Data.DataSetExtensions" #>
		<#@ assembly name="System.Xml" #>
		<#@ assembly name="System.Xml.Linq" #>
		<#@ import namespace="System.IO" #>
		<#@ import namespace="System.Data.SqlClient" #>
		<#@ import namespace="System.Data" #>
		<#@ import namespace="System.Collections.Generic" #>
		<#@ import namespace="System.Xml" #>
		<#@ import namespace="System.Xml.Linq" #>
		<#@ import namespace="System.Text" #>
		<#@ import namespace="System.Linq" #>
		<#
		string outputFileName = @"tableContent.txt";
		string dbConnection = @"Data Source=local;Initial Catalog=mydb;user=sa;password=sa";
		System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(dbConnection);
		#>
		//Some info like 'this is generated code, do not modify' or similar... 
		//this text (because it's out of the tt region) goes into the output file
		<#
		//again, the c# code...
				SqlConnection conn = new SqlConnection(dbConnection);
				conn.Open();
				PushIndent("\t");
				string query = "SELECT something FROM myTable";
				using (IDataReader reader = new SqlCommand(query, conn).ExecuteReader())
				{
					Write("Undefined = 0");
					while(reader.Read())
					{ 
						if (reader[0] != DBNull.Value) 
						{
							Write("Value=" + reader[0].ToString() + Environment.NewLine);
						}
					}
					WriteLine("");
				}
				PopIndent();
				conn.Close();
				
		#>
		//this goes into file end (could've also be there with Write function)
		<#
		//output to the desired file
		if (!String.IsNullOrEmpty(outputFileName))
		{
			File.WriteAllText(outputFileName, this.GenerationEnvironment.ToString());
			this.GenerationEnvironment.Remove(0, this.GenerationEnvironment.Length);
		}
		#>
