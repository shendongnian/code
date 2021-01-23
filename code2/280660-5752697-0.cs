    static void Main(string[] args)
    {
       string sdfFileName = args[0];
       using(var connection = new SqlCeConnection("Data Source = "+sdfFileName))
        {
          //connected to SQL Server Compact database (*.sdf)
        }
    }
