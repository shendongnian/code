    byte[] bytes = System.Text.Encoding.Default.GetBytes( "Hello" );
    StringBuilder sb = new StringBuilder();
    foreach ( byte b in bytes )
    {
        sb.AppendFormat( "{0:B}", b );
    }
    string binary = sb.ToString();
