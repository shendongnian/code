    Byte[] definition = null;
    Warning[] warnings = null;
    string parentFolder = "AdventureWorks Sample Reports";
    string parentPath = "/" + parentFolder;
    string filePath = "D:\\Program Files\\Microsoft SQL Server\\100\\Samples\\Reporting Services\\Report Samples\\AdventureWorks Sample Reports\\";
    public void Main()
    {
	rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
	//Create the parent folder
	try {
		rs.CreateFolder(parentFolder, "/", null);
		Console.WriteLine("Parent folder {0} created successfully", parentFolder);
	} catch (Exception e) {
		Console.WriteLine(e.Message);
	}
	//Publish the sample reports
	PublishReport("EmbeddedDatasource");
    }
    public void PublishReport(string reportName)
    {
	try {
		FileStream stream = File.OpenRead(filePath + reportName + ".rdl");
		definition = new Byte[stream.Length + 1];
		stream.Read(definition, 0, Convert.ToInt32(stream.Length));
		stream.Close();
	} catch (IOException e) {
		Console.WriteLine(e.Message);
	}
	try {
		warnings = rs.CreateReport(reportName, parentPath, false, definition, null);
		if ((warnings != null)) {
			Warning warning = default(Warning);
			foreach ( warning in warnings) {
				Console.WriteLine(warning.Message);
			}
		} else {
			Console.WriteLine("Report: {0} published successfully with no warnings", reportName);
		}
	} catch (Exception e) {
		Console.WriteLine(e.Message);
	}
	try {
		DataSourceDefinition definition = new DataSourceDefinition();
		definition.CredentialRetrieval = CredentialRetrievalEnum.Store;
		DataSourceReference reference = new DataSourceReference();
		definition.ConnectString = "Data Source=.;Initial Catalog=AdventureWorks";
		definition.UserName = "username";
		definition.Password = "password";
		definition.Extension = "SQL";
		definition.WindowsCredentials = true;
		DataSource[] sources = new DataSource[1];
		DataSource s = new DataSource();
		s.Item = definition;
		s.Name = "DataSource1";
		sources(0) = s;
		rs.SetItemDataSources("/AdventureWorks Sample Reports/EmbeddedDatasource", sources);
	} catch (Exception exp) {
		Console.WriteLine(exp.Message);
	}
    }
