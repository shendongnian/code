    static byte[] GetImageAsByteArray(string imageFilePath)
    
            {
    
                // Open a read-only file stream for the specified file.
    
                using (FileStream fileStream =
    
                    new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
    
                {
    
                    // Read the file's contents into a byte array.
    
                    BinaryReader binaryReader = new BinaryReader(fileStream);
    
                    return binaryReader.ReadBytes((int)fileStream.Length);
    
                }
    
            }
