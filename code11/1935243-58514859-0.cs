    public static string  DbFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Sqlite.db");
    public App()
    {
        this.InitializeComponent();
    
        using (SqliteConnection db = new SqliteConnection("Filename=" + DbFilePath)) 
        {
            db.Open();
            String tableCommand = "CREATE TABLE IF NOT EXISTS MyTable (Primary_Key INTEGER PRIMARY KEY AUTOINCREMENT, Text_Entry NVARCHAR(2048) NULL)";
            SqliteCommand createTable = new SqliteCommand(tableCommand, db);
            try
            {
                createTable.ExecuteReader();
            }
            catch (SqliteException e)
            {
                //Do nothing
            }
        }
        this.Suspending += OnSuspending;
    }
