    string text = "A01+B02+C03+D04+E05+F06+G07+H08+I09+J10+K11+L12+M13+N14+O15+P16";
    string[] parts = test.Split( '+' );
    StringBuilder output = new StringBuilder( );
    for( int i = 0; i < parts.Length; i++ )
    {
        if( i%4 == 0 )
        {
            output.Append( " " );
        }
        output.Append( parts[ i ] + "+" );
    }
