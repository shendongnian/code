    // provide read access to the file
    FileStream fs = new FileStream(media.Path, FileMode.Open,FileAccess.Read);
    // Create a byte array of file stream length
    byte[] ImageData = new byte[fs.Length];
    //Read block of bytes from stream into the byte array
    fs.Read(ImageData,0,System.Convert.ToInt32(fs.Length));
    //Close the File Stream
    fs.Close();
    string _base64String = Convert.ToBase64String (ImageData);
