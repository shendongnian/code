    public class Connection()
    {
        private Socket sock;
        // Pick whatever encoding works best for you.  Just make sure the remote 
        // host is using the same encoding.
        private Encoding encoding = Encoding.UTF8;
    
        public Connection(Socket s)
        {
            this.sock = s;
            // Start listening for incoming data.  (If you want a multi-
            // threaded service, you can start this method up in a separate
            // thread.)
            this.BeginReceive();
        }
        // Call this method to set this connection's socket up to receive data.
        private void BeginReceive()
        {
            this.sock.BeginReceive(
                    this.dataRcvBuf, 0,
                    this.dataRcvBuf.Length,
                    SocketFlags.None,
                    new AsyncCallback(this.OnBytesReceived),
                    this);
        }
        
        // This is the method that is called whenever the socket receives
        // incoming bytes.
        protected void OnBytesReceived(IAsyncResult result)
        {
            // End the data receiving that the socket has done and get
            // the number of bytes read.
            int nBytesRec = this.sock.EndReceive(result);
            // If no bytes were received, the connection is closed (at
            // least as far as we're concerned).
            if (nBytesRec <= 0)
            {
                this.sock.Close();
                return;
            }
            // Convert the data we have to a string.
            string strReceived = this.encoding.GetString(
                this.dataRcvBuf, 0, nBytesRec);
    
            // ...Now, do whatever works best with the string data.
            // You could, for example, look at each character in the string
            // one-at-a-time and check for characters like the "end of text"
            // character ('\u0003') from a client indicating that they've finished
            // sending the current message.  It's totally up to you how you want
            // the protocol to work.
            // Whenever you decide the connection should be closed, call 
            // sock.Close() and don't call sock.BeginReceive() again.  But as long 
            // as you want to keep processing incoming data...
            // Set up again to get the next chunk of data.
            this.sock.BeginReceive(
                this.dataRcvBuf, 0,
                this.dataRcvBuf.Length,
                SocketFlags.None,
                new AsyncCallback(this.OnBytesReceived),
                this);
            
        }
    }
