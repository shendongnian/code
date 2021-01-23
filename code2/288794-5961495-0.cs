    public void UDPListen(int UDPPort, IUDPListener listner)
    {
      ...
      listener.Notify("bla bla");
      ...
    }
    public class ServerClass : IUDPListener
    {
       ...
    
       public void Notify(string status)
       {
         // Callback from thread
         ...
       }
    
       // Method that starts thread
       public void StartThread() 
       {
         UDPClass clsUDP = new UDPClass();
         Thread clsUDPThread = new Thread(new ThreadStart(delegate() { clsUDP.UDPListen(64000, this); }));
         clsUDPThread.Start();
       }   
    }
