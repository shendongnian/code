    public void legitOpen(string nameOfFile)
    {
        legitOpenAsync(nameOfFile);
    }
    
    private async void legitOpenAsync(string nameOfFile)
    {
        var realPath = Path.Combine(Application.persistentDataPath, nameOfFile + ".pdf");
        var pdfPath = Path.Combine(Application.persistentDataPath, "PDFs");
        if (!System.IO.File.Exists(realPath))
        {
            if (!System.IO.Directory.Exists(pdfPath)
            {
                System.IO.Directory.CreateDirectory(pdfPath);
            }
            using(var sourceFile = File.Open(Path.Combine(Application.streamingAssetsPath, "PDFs", nameOfFile + ".pdf"), FileMode.Open, FileAccess.Read, FileShare.Read)
            {
                using(var targetFile = File.Open(realPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                {
                    await sourceFile.CopyToAsync(targetFile);
                }
            }
        }
       
        Application.OpenURL(realPath);
    }
    
    
