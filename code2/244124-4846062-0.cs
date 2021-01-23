    public static void Main(string[] args) {
       string connectionString = "URI=file:f-spot.photos.db,version=3"; //<-- version is set to 3
       IDbConnection dbcon;
       dbcon = (IDbConnection) new SqliteConnection(connectionString);
       dbcon.Open();
       dbcon.Close();
       dbcon = null;
    }
