    if (Directory.Exists(backupDir))
    {
      // Move actual directory to a random directory in temp
      string tmpDir = Path.Combine(Path.GetTempPath(),Path.GetFileNameWithoutExtension(Path.GetTempFileName()));
      Directory.Move(appPath, tmpDir);
      Directory.Move(backupDir, appPath);
    }
