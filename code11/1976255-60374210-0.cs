    string path = Path.Combine(
         System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
          "Service.db3");
            SqliteConnection cn = new SqliteConnection("Filename=" + path);
            List<String> entries = new List<string>();
            SqliteCommand sqCommand = (SqliteCommand)cn.CreateCommand();
            sqCommand.CommandText = "SELECT ID FROM Members ";
            cn.Open();
             SqliteDataReader sqReader = sqCommand.ExecuteReader();
            if (sqReader.HasRows)
            {
            }
            else
            {
            }
