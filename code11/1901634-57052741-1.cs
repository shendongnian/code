    public void OpenPDF(string filename)
    {
        TextAsset pdfTem = Resources.Load("PDFs/" + filename, typeof(TextAsset)) as TextAsset;
        var filePath = Path.Combine(Application.persistentDataPath, filename + ".pdf";
        System.IO.File.WriteAllBytes(filePath), pdfTem.bytes);
        Application.OpenURL(filePath);
    }
    public void legitOpen(string nameOfFile)
    {
        string realPath = Path.Combine(Application.persistentDataPath, nameOfFile + ".pdf");
        if (!System.IO.File.Exists(realPath))
        {
            if (!System.IO.Directory.Exists(Path.Combine(Application.persistentDataPath, "PDFs"))
            {
                System.IO.Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "PDFs"));
            }
            WWW reader = new WWW(Path.Combine(Application.streamingAssetsPath, "PDFs", nameOfFile + ".pdf");
            while (!reader.isDone) { }
            System.IO.File.WriteAllBytes(realPath, reader.bytes);
        }
        Application.OpenURL(realPath);
    }
    
