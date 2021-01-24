    // on success, buffer contains the image data. Otherwise it is null.
    private bool ValidateUploadedImageContent(
        out byte[] buffer,
        HttpPostedFileBase uploadedFile,
        string imageFileName)
    {
        buffer = null;
        if (Path.GetExtension(imageFileName).Equals(".svg", StringComparison.OrdinalIgnoreCase))
        {
            if (uploadedFile.ContentLength > 0)
            {
                var reader = new BinaryReader(inputStream);
                buffer = reader.ReadBytes((int)uploadedFile.ContentLength);
                var parsedData = Encoding.UTF8.GetString(buffer, 0, buffer.Length).TrimEnd('\0');
                return parsedData.ContainsAny(Constants.InsecureStrings, StringComparison.CurrentCultureIgnoreCase);
            }
        }
        return false;
    }
