    class Class1 {
        public string Hostname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool GiveUpSecurityAndAcceptAnySshHostKey { get; set; }
        public string LogPath { get; set; }
        public bool IsDebug { get; set }
        public int Downloadwaitmiliseconds { get; set; }
    
        public void setValues(string hostname, string username, string password, int port /* adding other values*/) 
        {
            Hostname = hostname;
            Username = username
            Port = port;
            /* The other values */
        }
    
    }
