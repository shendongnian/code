    if (Directory.Exists(backupDir))
    {
      string tmpDir = Path.Combine(Path.GetTempPath(),Path.GetFileNameWithoutExtension(Path.GetTempFileName()));
      Directory.Move(appPath, tmpDir);
      Directory.Move(backupDir, appPath);
    }
