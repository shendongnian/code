    foreach (MultipartFileData file in provider.FileData)
    {
    
        var fileName = file.Headers.ContentDisposition.FileName.Trim('\"').Trim();
        if (fileName.EndsWith(".png"))
        {
            var img = Image.FromFile(file.LocalFileName);
            if (img.Width == 200 && img.Height == 200)
            {
                //here is ur logic
            }
        }
    }
