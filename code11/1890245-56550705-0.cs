    public SettingDB SelectValueFromTableSettings(string name)
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        try
        {
            using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Settings.db")))
            {
                return connection.Query<SettingDb>("SELECT Value FROM SettingDb WHERE Name=?", name).FirstOrDefault();
            }
        }
        catch (SQLiteException ex)
        {
            Log.Info("SQLiteEx", ex.Message);
            return null;
        }
    }
