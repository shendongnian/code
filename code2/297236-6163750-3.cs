    int myInt1 = 1234;
    int myInt2 = 5678;
    byte[] temp1 = BitConverter.GetBytes( myInt1 );
    byte[] temp2 = BitConverter.GetBytes( myInt2 );
    if ( BitConverter.IsLittleEndian ) {
        Array.Reverse( temp1 );
        Array.Reverse( temp2 );
    }
    byte[] buffer = new byte[ temp1.Length + temp2.Length ];
    Array.Copy( temp1, 0, buffer, 0, temp1.Length );
    Array.Copy( temp2, 0, buffer, temp1.Length, temp2.Length );
    return buffer;
