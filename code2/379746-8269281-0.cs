    public static class MyConsole
    {
        public static void WriteLine( string message, string whatever )
        {
            // send to the net
            if( mTcpSocket.Connected )
                mTcpSocket.Send( message );
            // in case the server is not there we still have regular output
            Console.WriteLine( message );
        }
    }
