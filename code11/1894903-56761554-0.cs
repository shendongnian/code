    foreach (FileInfo file in new DirectoryInfo(path).GetFiles("*.txt"))
    {
        string asset = File.ReadAllText(file.FullName);
        if (asset.Contains(AssetT.Text))
        {
            Results.Text = asset;
            // No use reading more files unless we're going
            // to save the contents to another variable
            break; 
        }
    }
