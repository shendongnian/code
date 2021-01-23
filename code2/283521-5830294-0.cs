    public T ReadMemory<T>( uint adr )
    {
        if ( adr != int.MinValue )
        {
            if ( typeof( T ) == typeof( int ) )
            {
                return (T)Convert.ChangeType( MemoryReader.ReadInt( adr ), typeof( T ) );
            }
            else
            {
                System.Windows.Forms.MessageBox.Show( "Unknown read type" );
            }
        }
        return default( T );
    }
