    // A Client which listens to several servers
    public class Client
    {
    private static object logSync = new object();
    private readonly Dictionary<string, Server> servers = new Dictionary<string, Server>();// .... some code for initialization ...
    
    // Disposing a server. 
    public void Dispose (string serverName)
    {
        //  the lock needed here is on private variable. This purpose cannot be achieved with a      
        //  lock on private static object. Well you can achieve the purpose but you will block
        //  all Client instances when you do so, which is pointless.
        //  Also notice that services is readonly, which is convenient
        //  because that is the object we took a lock on. The lock is on the same object always
        //  there is no need to unnecessarily create objects for locks.  
        lock(services)
        {
            // ... Do something cleanup here ...
            Server server;
            if (servers.TryGetValue(serverName, out server))
            {
                 server.Dispose();
                 servers.Remove(serverName);
            }
        }
    }
    
    // on some message that has to be logged  
    public void OnMessage(string message, Server server)
    {
        // This makes sure that all clients log to the same sink and 
        // the messages are processed in the order of receipt
        lock (logSync)
        {
            Log(evt);
        }
    }
 
}
