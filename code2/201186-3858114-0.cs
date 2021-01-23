    		static void T2( )
		{
			var x = new
			{
				a = new { a1 = new Type1( "x.1" ), a2 = new Type2( 1 ), a3 = new Type3( '1' ) },
				b = new { b1 = new Type1( "x.2" ), b2 = new Type2( 2 ), b3 = new Type3( '2' ) }
			};
			var y = new
			{
				a = new { a1 = new Type1( "y.1" ), a2 = new Type2( 1 ), a3 = new Type3( '1' ) },
				b = new { b1 = new Type1( "y.2" ), b2 = new Type2( 2 ), b3 = new Type3( '2' ) }
			};
			var z = new
			{
				a = new { a1 = new Type1( "y.1" ), a2 = new Type3( '1' ) },
				b = new { b1 = new Type3( 'z' ), b2 = new Type2( 2 ) }
			};
			Console.WriteLine( new string( '-', 40 ) );
			Console.WriteLine( "Anonymous object \"x\" is named {0}.", x.GetType( ) );
			Console.WriteLine( "Anonymous object \"y\" is named {0}.", y.GetType( ) );
			Console.WriteLine( "Anonymous object \"z\" is named {0}.", z.GetType( ) );
			Console.WriteLine( new string( '-', 40 ) );
			Console.Write( "Anonymous object \"x\" == \"y\"? " );
			Console.WriteLine( x.Equals( y ) ? "Yes" : "No" );
			Console.Write( "Anonymous object \"x\" == \"z\"? " );
			Console.WriteLine( x.Equals( z ) ? "Yes" : "No" );
			var x2 = new
			{
				a = new { a1 = new Type1( "x.1" ), a2 = new Type2( 1 ), a3 = new Type3( '1' ) },
				b = new { b1 = new Type1( "x.2" ), b2 = new Type2( 2 ), b3 = new Type3( '2' ) }
			};
			Console.Write( "Anonymous object \"x\" == \"x2\"? " );
			Console.WriteLine( x.Equals( x2 ) ? "Yes" : "No" );
			// Uncomment it to give:
			//Error	1	Cannot implicitly convert type 'AnonymousType#1' to 'AnonymousType#2'
	#if GiveMeAnError
			z = new
			{
				a = new { a1 = new Type1( "z.1" ), a2 = new Type2( 1 ), a3 = new Type3( '1' ) },
				b = new { b1 = new Type1( "z.2" ), b2 = new Type2( 2 ), b3 = new Type3( '2' ) }
			};
			Console.WriteLine( "Anonymous object \"z\" now is named {0}.", z.GetType( ) );
			Console.Write( "Anonymous object \"x\" == \"z\"? " );
			Console.WriteLine( x.Equals( z ) ? "Yes" : "No" );
	#endif
			Console.ReadKey( );
		}
