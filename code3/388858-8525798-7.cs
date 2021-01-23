    private static readonly ulong[] _base62Table = new ulong[] { 839299365868340224, 13537086546263552, 218340105584896, 3521614606208, 56800235584, 916132832, 14776336, 238328, 3844, 62, 1 };  
    private static readonly char[] _base62Output = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    
    public static string EncodeFromBase10( ulong number )
    {
        byte i = 0;
        ulong occurs;
        char* buffer = stackalloc char[_base62Table.Length + 1];
    
        while( i < _base62Table.Length )
        {
            occurs = number / _base62Table[i];
            number -= _base62Table[i] * occurs;
    
            buffer[i] = _base62Output[occurs];
            i++;
        }
    
        buffer[i] = char.MinValue;
    
        while( *buffer == '0' )
        {
            buffer++;
        }
    
        return new string( buffer );
    }
