    FileStream fileStream = new FileStream( filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite );
    
    BinaryReader binaryReader = new BinaryReader( fileStream );
    binaryReader.BaseStream.Seek( 0, SeekOrigin.Begin );
    byte[] verifyArray = binaryReader.ReadBytes( 32 );
    binaryReader.Close();
    
    ConvertToString( BitConverter.ToString( verifyArray ) );
    
    private void ConvertToString( string hex )
    {
        StringBuilder builder = new StringBuilder();
    
        string[] splitHex = hex.Split( new char[] { '-' } );
        for (int i = 0; i < splitHex.Length; i++)
        {
           int value = Convert.ToInt32( splitHex[i], 16 );
           string stringValue = char.ConvertFromUtf32( value );
           char charValue = (char)value;
            if( value != 0 )
               builder.Append( stringValue );
         }
     }
