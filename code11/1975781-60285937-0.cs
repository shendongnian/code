    private void deleteRegistersFromFilesThatWasRemoved(string path)
    {
        // add local files to list
        List<string> allFiles = new List<string>();
        string[] dirs = Directory.GetDirectories(path, "*", 
        SearchOption.TopDirectoryOnly);
        foreach (var dir in dirs)
        {
            string[] files = Directory.GetFiles(dir, "*", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                    if(file != path)
                    {
                        allFiles.Add(file);
                    }
                }
            }
            // list for file records in the database
            List<string> record = new List<string>();
            string queryfiles = //your query
            SqlCommand cmd = new SqlCommand(queryfiles, connection);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
             // I have path and file name separated that's why here's a string sum
                string r = read[2].ToString() + read[1].ToString();
                record.Add(r);
            
            }
            cmd.Connection.Close();
            for (int i = 0; i < record.Count; i++)
            {
                if (!allFiles.Contains(record[i]))
                {
                    // do something if the record on the database is not in the local 
                    //files list
                }
            }
        }
    }
