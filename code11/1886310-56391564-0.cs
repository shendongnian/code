    public delegate void CombinationFoundDelegate(object sender, int port, string ip); 
    //note that it would be better to create class derived from EventArgs instead of passing bare arguments in this delegate
    public class CmdExec
    {
        public event CombinationFoundDelegate CombinationFound;
        public void Runcmd()
        {
           //do your work and call event when necessary:
           if(CanConnect(ip, port))
             CombinationFound?.Invoke(this, port, ip);
        }
    }
