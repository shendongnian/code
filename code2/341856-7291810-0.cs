    int numberOfBytes = 100;
    byte newByte = 0x1;
    using ( var newFile = new FileStream( @"C:\newfile.dat", FileMode.CreateNew, FileAccess.Write ) )
    {
        for ( var i = 0; i < numberOfBytes; i++ )
        {
            newFile.WriteByte( newByte );
        }
        using ( var oldFile = new FileStream( @"C:\oldfile.dat", FileMode.Open, FileAccess.Read ) )
        {
            var reader = new BinaryReader( oldFile );
            var buffer = reader.ReadBytes( (int) oldFile.Length );
            newFile.Write( buffer, 0, buffer.Length );
            reader.Close();
        }
    }
    // Rename and delete files, or whatever you want to do
