    private static bool CanUploadBatchOfFiles(HttpPostedFileBase[] files)
    {
        foreach (var file in files)
        {
            if (file.FileName.EndsWith(".zip"))
            {
                // Part one of the solution
                Stream fileCopy = new MemoryStream();
                file.InputStream.CopyTo(fileCopy);
    
                using (ZipArchive zipFile = new ZipArchive(fileCopy))
                {
                    foreach (ZipArchiveEntry entry in zipFile.Entries)
                    {
                        // Code left out
                    }
                }
    
                // Part two of the solution
                file.InputStream.Position = 0;
            }
        }
    
        return true;
    }
