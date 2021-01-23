    try {
      SerialPort port = new SerialPort( "COM9", 9600, Parity.None, 8, StopBits.One );
      port.Open();
      string Unreadz = "0";
      while ( true ) {
        Unreadz = CheckMail();
        Console.WriteLine( "Unread Mails: " + Unreadz );
        if ( !Unreadz.Equals( "0" ) ) port.Write( "m" );
        else port.Write( "n" );
      }
    } catch ( Exception ee ) { Console.WriteLine( ee.Message ); 
    } finally { System.Threading.Thread.Sleep(1000*60); }
