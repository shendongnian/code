    string appPath = string.Format(@"{0}{1}{2}{1}{3}",
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        Path.DirectorySeparatorChar, "MyCompany", "MyProduct"
      );
    string dbFile = "database.swf";
    string dbFilePath = Path.Combine(appPath, dbFile);
    if (!File.Exists(dbFilePath)) {
      string connStr = string.Format("Data Source={0}; Password ={1}", dbFilePath, "1234567");
      using (SqlCeEngine engine = new SqlCeEngine(connStr)) {
        engine.CreateDatabase();
      }
      using (SqlCeConnection conn = new SqlCeConnection(connStr)) {
        try {
          conn.Open();
          using (SqlCeCommand cmd = new SqlCeCommand("CREATE TABLE myTable (col1 int, col2 ntext)", conn)) {
            cmd.ExecuteNonQuery();
          }
        } catch { } finally {
          conn.Close();
        }
      }
    }
