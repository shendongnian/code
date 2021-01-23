    try
    {
        using (var img = Image.FromStream(someFileStream))
        {
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
            {
                // it's a png
            }
            else if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
            {
                // it's a jpeg
            }
            ...
        }
    }
    catch (Exception ex)
    {
        // ... it's probably not an image format that can be handled
    }
