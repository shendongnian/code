	static IEnumerable<(string, Color)> parse( byte[] data )
	{
		for( int p = 0; p < data.Length; )
		{
			// '\0'
			if( 0 != data[ p++ ] ) throw new ApplicationException();
			// String length byte
			int length = data[ p++ ];
			// The string; assuming the encoding is UTF8
			string name = Encoding.UTF8.GetString( data, p, length );
			p += length;
			// '\0'
			if( 0 != data[ p++ ] ) throw new ApplicationException();
			// 3 color bytes, assuming the order is RGBA
			Color color = Color.FromArgb( 0xFF, data[ p ], data[ p + 1 ], data[ p + 2 ] );
			p += 3;
			yield return (name, color);
		}
	}
