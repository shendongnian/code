    try
    {
        // open a connection to the database for test
    }
    catch (SystemException ex) // Change exception type based on your underlying data provider
    {
        if (ex.Message.ToLower().Contains("already exists. choose a different database name"))
        {
            var match = Regex.Match(ex.Message, "database '(.*)' already exists.", 
               RegexOptions.IgnoreCase);
    
            if (match.Success)
            {
                String dbFileName = match.Groups[1].Value;
                Process p = new Process();
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.FileName = String.Format("{0}/Tools/SSEUtil.exe", 
                  Environment.CurrentDirectory);
                p.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                p.StartInfo.Arguments = String.Format("-d \"{0}\"", dbFileName);
    
                p.Start();
            }
        }
    }
