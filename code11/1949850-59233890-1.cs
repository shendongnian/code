    //connection string in web.config
    //Data Source=192.168.1.101\sql2014;Initial Catalog=MIS_Keshavarzi_980906;user id=sa;pwd=sa_123; Connect Timeout=60000;
    string connectionString = 
    System.Configuration.ConfigurationManager.AppSettings["ABSConnectionString"];
    SqlConnectionStringBuilder connectionStringBuilder = new 
    SqlConnectionStringBuilder(connectionString);
    connectionStringBuilder.WorkstationID = Helpers.UserId.ToString(); //get work station id
    connectionStringBuilder.ApplicationName = "EntityFramework"; //set application name
