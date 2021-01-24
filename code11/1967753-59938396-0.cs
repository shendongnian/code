    if (Path.GetExtension(imageFileName).Equals(".svg", StringComparison.OrdinalIgnoreCase))
    {
        if (uploadedFile.ContentLength > 0)
        {
            var reader = new BinaryReader(uploadedFile.InputStream);           
            reader.BaseStream.Position = 0;
            var buffer = reader.ReadBytes((int)uploadedFile.ContentLength);
            var parsedData = Encoding.UTF8.GetString(buffer, 0, buffer.Length).TrimEnd('\0');
            return parsedData.ContainsAny(Constants.InsecureStrings, StringComparison.CurrentCultureIgnoreCase);            
        }
    }
                
    return false;
