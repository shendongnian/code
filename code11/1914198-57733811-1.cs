    public static void MergePdf(string srcPath, string destFile)
    {
        var list = Directory.GetFiles(Path.GetFullPath(srcPath));
        if (string.IsNullOrWhiteSpace(srcPath) || string.IsNullOrWhiteSpace(destFile) || list.Length <= 1)
            return;
        var files = list.Select(File.ReadAllBytes).ToList();
        using (var dest = new org.pdfclown.files.File(new org.pdfclown.bytes.Buffer(files[0])))
        {
            var document = dest.Document;
            var builder = new org.pdfclown.tools.PageManager(document);
            foreach (var file in files.Skip(1))
            {
                using (var src = new org.pdfclown.files.File(new org.pdfclown.bytes.Buffer(file)))
                { builder.Add(src.Document); }
            }
    
            dest.Save(destFile, SerializationModeEnum.Incremental);
            dest.Dispose();
        }
    }
