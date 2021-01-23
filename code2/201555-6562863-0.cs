    		static void Main( string[] args ) {
			try {
				TcpClient tcpclient = new TcpClient();
				tcpclient.Connect( "imap.gmail.com", 993 );
				SslStream sslstream = new SslStream( tcpclient.GetStream() );
				sslstream.AuthenticateAsClient( "imap.gmail.com" );
				if ( sslstream.IsAuthenticated ) {
					StreamWriter sw = new StreamWriter( sslstream );
					StreamReader sr = new StreamReader( sslstream );
					sw.WriteLine( "tag LOGIN user@gmail.com pass" );
					sw.Flush();
					ReadResponse( "tag", sr );
					sw.WriteLine( "tag2 EXAMINE inbox" );
					sw.Flush();
					ReadResponse( "tag2", sr );
					sw.WriteLine( "tag3 LOGOUT" );
					sw.Flush();
					ReadResponse( "tag3", sr );
				}
			}
			catch ( Exception ex ) {
				Console.WriteLine( ex.Message );
			}
		}
		private static void ReadResponse( string tag, StreamReader sr ) {
			string response;
			while ( ( response = sr.ReadLine() ) != null ) {
				Console.WriteLine( response );
				if ( response.StartsWith( tag, StringComparison.Ordinal ) ) {
					break;
				}
			}
		}
 
