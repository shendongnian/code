    byte[] bytes = System.Text.Encoding.Default.GetBytes( "Hello" );
    foreach ( byte b in bytes )
    {
        String.Format( "{0:B}", b );
    }
