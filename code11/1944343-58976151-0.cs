	/// <summary>Load 4 pixels of RGB</summary>
	static unsafe Vector128<int> load4( byte* src )
	{
		return Sse2.LoadVector128( (int*)src );
	}
	/// <summary>Pack red channel of 8 pixels into ushort values in [ 0xFF00 .. 0 ] interval</summary>
	static Vector128<ushort> packRed( Vector128<int> a, Vector128<int> b )
	{
		Vector128<int> mask = Vector128.Create( 0xFF );
		a = Sse2.And( a, mask );
		b = Sse2.And( b, mask );
		return Sse2.ShiftLeftLogical128BitLane( Sse41.PackUnsignedSaturate( a, b ), 1 );
	}
	/// <summary>Pack green channel of 8 pixels into ushort values in [ 0xFF00 .. 0 ] interval</summary>
	static Vector128<ushort> packGreen( Vector128<int> a, Vector128<int> b )
	{
		Vector128<int> mask = Vector128.Create( 0xFF00 );
		a = Sse2.And( a, mask );
		b = Sse2.And( b, mask );
		return Sse41.PackUnsignedSaturate( a, b );
	}
	/// <summary>Pack blue channel of 8 pixels into ushort values in [ 0xFF00 .. 0 ] interval</summary>
	static Vector128<ushort> packBlue( Vector128<int> a, Vector128<int> b )
	{
		a = Sse2.ShiftRightLogical128BitLane( a, 1 );
		b = Sse2.ShiftRightLogical128BitLane( b, 1 );
		Vector128<int> mask = Vector128.Create( 0xFF00 );
		a = Sse2.And( a, mask );
		b = Sse2.And( b, mask );
		return Sse41.PackUnsignedSaturate( a, b );
	}
	/// <summary>Load 8 pixels, split into RGB channels.</summary>
	static unsafe void loadRgb( byte* src, out Vector128<ushort> red, out Vector128<ushort> green, out Vector128<ushort> blue )
	{
		var a = load4( src );
		var b = load4( src + 16 );
		red = packRed( a, b );
		green = packGreen( a, b );
		blue = packBlue( a, b );
	}
	const ushort mulRed = (ushort)( 0.29891 * 0x10000 );
	const ushort mulGreen = (ushort)( 0.58661 * 0x10000 );
	const ushort mulBlue = (ushort)( 0.11448 * 0x10000 );
	/// <summary>Compute brightness of 8 pixels</summary>
	static unsafe Vector128<short> brightness( Vector128<ushort> r, Vector128<ushort> g, Vector128<ushort> b )
	{
		r = Sse2.MultiplyHigh( r, Vector128.Create( mulRed ) );
		g = Sse2.MultiplyHigh( g, Vector128.Create( mulGreen ) );
		b = Sse2.MultiplyHigh( b, Vector128.Create( mulBlue ) );
		var result = Sse2.AddSaturate( Sse2.AddSaturate( r, g ), b );
		return Vector128.AsInt16( Sse2.ShiftRightLogical( result, 8 ) );
	}
	/// <summary>Convert buffer from RGBA to grayscale. If your image has padding, you'll want to call this once per line, not for the complete image.</summary>
	static unsafe void convertToGrayscale( byte* src, byte* dst, int count )
	{
		byte* srcEnd = src + count * 4;
		while( src < srcEnd )
		{
			loadRgb( src, out var r, out var g, out var b );
			var low = brightness( r, g, b );
			loadRgb( src + 32, out r, out g, out b );
			var hi = brightness( r, g, b );
			var bytes = Sse2.PackUnsignedSaturate( low, hi );
			Sse2.Store( dst, bytes );
			src += 64;
			dst += 16;
		}
	}
