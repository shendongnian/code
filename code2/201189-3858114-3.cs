    		static void T1( )
		{
			var x = new object[ ]  
			{  
				new object[] { new Type1("x.1"), new Type2(1), new Type3('1') },  
				new object[] { new Type1("x.2"), new Type2(2) , new Type3('2')}  
			};
			var y = new object[ ]  
			{  
				new object[] { new Type1("y.1"), new Type2(1), new Type3('1') },  
				new object[] { new Type1("y.2"), new Type2(2) , new Type3('2')}  
			};
			var z = new object[ ]  
			{  
				new object[] { new Type1("y.1"), new Type3('1') },  
				new object[] { new Type3('z'), new Type2(2)}  
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
			var x2 = new object[ ]  
			{  
				new object[] { new Type1("x.1"), new Type2(1), new Type3('1') },  
				new object[] { new Type1("x.2"), new Type2(2) , new Type3('2')}  
			};
			Console.Write( "Anonymous object \"x\" == \"x2\"? " );
			Console.WriteLine( x.Equals( x2 ) ? "Yes" : "No" );
			z = new object[ ]  
			{  
				new object[] { new Type1("x.1"), new Type2(1), new Type3('1') },  
				new object[] { new Type1("x.2"), new Type2(2) , new Type3('2')}  
			};
			Console.WriteLine( "Anonymous object \"z\" now is named {0}.", z.GetType( ) );
			Console.Write( "Anonymous object \"x\" == \"z\"? " );
			Console.WriteLine( x.Equals( z ) ? "Yes" : "No" );
			Console.Write( "Anonymous object \"x\" == \"z\" (memberwise)? " );
			Console.WriteLine(
				x[ 0 ].Equals( z[ 0 ] )
				&& x[ 1 ].Equals( z[ 1 ] )
				? "Yes" : "No" );
			Console.ReadKey( );
		}
