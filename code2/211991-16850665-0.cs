    void Main()
    {
    	var assemblyName = "tSQLtCLR";
    	var serverName = "localhost";
    	var databaseName = "MyDb";
    	var targetDir = Environment.ExpandEnvironmentVariables("%TEMP%");
    	var targetFile = Path.Combine(targetDir, assemblyName) + ".dll";
    	
    	var sql = @"SELECT AF.content FROM sys.assembly_files AF JOIN sys.assemblies A ON AF.assembly_id = A.assembly_id where AF.file_id = 1 AND A.name = @assemblyName";
    	
    	var connectionString = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=true", serverName, databaseName);
    	using(var connection = new System.Data.SqlClient.SqlConnection(connectionString)){
    		connection.Open();
    		
    		var command = connection.CreateCommand();
    		command.CommandText = sql;
    		command.Parameters.Add("@assemblyName", assemblyName);
    		
    		using(var reader = command.ExecuteReader()){
    			if(reader.Read()){
    				var bytes = reader.GetSqlBytes(0);
    				
    				File.WriteAllBytes(targetFile, bytes.Value);
    				Console.WriteLine(targetFile);
    			}else{
    				throw new Exception("No rows returned");
    			}
    		}
    	}
    }
