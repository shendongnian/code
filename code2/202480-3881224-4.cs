    installPath = @"C:\Program Files (x86)\MyApp\";
    using (FileStream userFile = new FileStream(
        Path.Combine(installPath, "storedUsers.txt"),
        FileMode.OpenOrCreate, FileAccess.Read))
    using (StreamReader userStream = new StreamReader(userFile))
    {
        string line;
        while ((line = userStream.ReadLine()) != null)
        {
            string[] parts = line.Split(',');
            int userId;
            if (Int32.TryParse(parts[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out userId))
                storedUsers.Add(userId);
        }
    }
