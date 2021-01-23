    public bool ValidateFileDimensions()
    {
        using(System.Drawing.Image myImage =
               System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream))
        {
            return (myImage.Height == 140 && myImage.Width == 140);
        }
    }
