    private readonly SqliteConnection db;
    
    public SqliteHelper(string fileLocation)
    {
         fileName = fileLocation;
         backupName = fileLocation.Split('.').First() + ".backup";
    
         db = new SqliteConnection("Filename=./" + fileLocation, true);
         db.Open();
    } 
