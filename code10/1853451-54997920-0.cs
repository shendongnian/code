    public byte[] LoadImage(string filename)
    { 
        var image UIImage.FromFile(filename);
    
        using (NSData imageData = image.AsPNG()) {
          byte[] myByteArray = new Byte[imageData.Length];
       System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes,myByteArray, 0, Convert.ToInt32(imageData.Length));
        return myByteArray;
     }
