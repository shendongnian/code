    //for readability, I changed the variable name to myProgramsVersion
    using (SqlCon = new MySqlConnection(connString))
    {
        SqlCon.Open();
        string command = "SELECT * FROM version where version > '" + myProgramsVersion + "' ORDER BY version";
        MySqlCommand GetLatestVersion = new MySqlCommand(command, SqlCon);
        using (MySqlDataReader DR = GetLatestVersion.ExecuteReader())
        {
            while (DR.Read())
            {
                string LatestVersion = Convert.ToString(DR.GetValue(1));
                string WebURL = Convert.ToString(DR.GetValue(2));
                update.DownloadProgressChanged += new DownloadProgressChangedEventHandler(download);
                update.DownloadFileCompleted += new AsyncCompletedEventHandler(extration);
                update.DownloadFileAsync(new Uri(WebURL), tempFilePath + "patch" + Latest_Version + ".zip");
            }
        }
    }
