    // minmal flawless UDP listener per PretorianNZ
    
    using System.Collections;
    using System;
    using System.Net.Sockets;
    using System.Net;
    using System.Threading;
    
    void Start()
       {
       listenThread = new Thread (new ThreadStart (SimplestReceiver));
       listenThread.Start();
       }
    
    private Thread listenThread;
    private UdpClient listenClient;
    private void SimplestReceiver()
       {
       Debug.Log(",,,,,,,,,,,, Overall listener thread started.");
    
       IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Any, 1260);
       listenClient = new UdpClient(listenEndPoint);
       Debug.Log(",,,,,,,,,,,, listen client started.");
       
       while(true)
          {
          Debug.Log(",,,,, listen client listening");
    
          try
             {
             Byte[] data = listenClient.Receive(ref listenEndPoint);
             string message = Encoding.ASCII.GetString(data);
             Debug.Log("Listener heard: " +message);
             }
          catch( SocketException ex)
             {
             if (ex.ErrorCode != 10060)
                Debug.Log("a more serious error " +ex.ErrorCode);
             else
                Debug.Log("expected timeout error");
             }
          
          Thread.Sleep(10);	// tune for your situation, can usually be omitted
          }
       }
    
    void OnDestroy() { CleanUp(); }
    void OnDisable() { CleanUp(); }
    // be certain to catch ALL possibilities of exit in your environment,
    // or else the thread will typically live on beyond the app quitting.
    
    void CleanUp()
       {
       Debug.Log ("Cleanup for listener...");
       
       // note, consider carefully that it may not be running
       listenClient.Close();
       Debug.Log(",,,,, listen client correctly stopped");
       
       listenThread.Abort();
       listenThread.Join(5000);
       listenThread = null;
       Debug.Log(",,,,, listener thread correctly stopped");
       }
