    public partial class MainWindow
    {
    	public MainWindow()
    	{
    		InitializeComponent();
    		UsersDataGrid.ItemsSource = GetUsers();
    	}
    
    	private static IEnumerable<User> GetUsers()
    	{
    		var users = new List<User>
    		{
    			new User {Id = 1, Name = "User1", Username = "u123"},
    			new User {Id = 2, Name = "User2", Username = "u321"},
    			new User {Id = 3, Name = "User3", Username = "u852"},
    		};
    
    		return users;
    	}
    
    	private void ToExcelButton_OnClick(object sender, RoutedEventArgs e)
    	{
    		var d = UsersDataGrid.ItemsSource.Cast<User>();
    		var data = ToDataTable(d.ToList());
    		ToExcelFile(data, "test.xlsx");
    	}
    
    	public static DataTable ToDataTable<T>(List<T> items)
    	{
    		var dataTable = new DataTable(typeof(T).Name);
    
    		//Get all the properties
    		var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    		foreach (var prop in properties)
    		{
    			//Defining type of data column gives proper data table 
    			var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
    			//Setting column names as Property names
    			dataTable.Columns.Add(prop.Name, type);
    		}
    		foreach (var item in items)
    		{
    			var values = new object[properties.Length];
    			for (var i = 0; i < properties.Length; i++)
    			{
    				//inserting property values to data table rows
    				values[i] = properties[i].GetValue(item, null);
    			}
    			dataTable.Rows.Add(values);
    		}
    		//put a breakpoint here and check data table
    		return dataTable;
    	}
    
    	public static void ToExcelFile(DataTable dataTable, string filePath, bool overwriteFile = true)
    	{
    		if (File.Exists(filePath) && overwriteFile)
    			File.Delete(filePath);
    
    		using (var connection = new OleDbConnection())
    		{
    			connection.ConnectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};" +
    										  "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
    			connection.Open();
    			using (var command = new OleDbCommand())
    			{
    				command.Connection = connection;
    				var columnNames = (from DataColumn dataColumn in dataTable.Columns select dataColumn.ColumnName).ToList();
    				var tableName = !string.IsNullOrWhiteSpace(dataTable.TableName) ? dataTable.TableName : Guid.NewGuid().ToString();
    				command.CommandText = $"CREATE TABLE [{tableName}] ({string.Join(",", columnNames.Select(c => $"[{c}] VARCHAR").ToArray())});";
    				command.ExecuteNonQuery();
    				foreach (DataRow row in dataTable.Rows)
    				{
    					var rowValues = (from DataColumn column in dataTable.Columns select (row[column] != null && row[column] != DBNull.Value) ? row[column].ToString() : string.Empty).ToList();
    					command.CommandText = $"INSERT INTO [{tableName}]({string.Join(",", columnNames.Select(c => $"[{c}]"))}) VALUES ({string.Join(",", rowValues.Select(r => $"'{r}'").ToArray())});";
    					command.ExecuteNonQuery();
    				}
    			}
    
    			connection.Close();
    		}
    	}
    }
