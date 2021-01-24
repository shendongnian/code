public Form2()
{
    InitializeComponent();
    Thread serverThread = new Thread(() => ExecuteServer("test"));
    serverThread.Start();
}
A few things to note here though.  
First of all, you should never start long running threads inside the constructor. Use the `Load` event for that. You can create a eventhandler for it if you double click on the form in the designer. You can also do something like this:  
public Form2()
{
    InitializeComponent();
    this.Load += (o, e) => StartServer();
}
private void StartServer() 
{
    Thread serverThread = new Thread(() => ExecuteServer("test"));
    serverThread.Start();
}
Next thing to note would be that you currently have no way of stopping the thread other than sending the right data to the socket. You should at least use a `volatile bool` instead of the `true` in the outer while loop.  
Also you should use `Application.Exit` as little as possible. With this thread solution, I would suggest just breaking out of the while loop and executing some closing action at the end of the thread-method. Your `ExecuteServer`-method could look something like this:  
public static void ExecuteServer(string pwd, Action closingAction)
{
    // Establish the local endpoint  
    // for the socket. Dns.GetHostName 
    // returns the name of the host  
    // running the application. 
    IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
    IPAddress ipAddr = ipHost.AddressList[0];
    IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);
    // Creation TCP/IP Socket using  
    // Socket Class Costructor 
    Socket listener = new Socket(ipAddr.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);
    try
    {
        // Using Bind() method we associate a 
        // network address to the Server Socket 
        // All client that will connect to this  
        // Server Socket must know this network 
        // Address 
        listener.Bind(localEndPoint);
        // Using Listen() method we create  
        // the Client list that will want 
        // to connect to Server 
        listener.Listen(10);
        while (_shouldContinue)
        {
            //Console.WriteLine("Waiting connection ... ");
            // Suspend while waiting for 
            // incoming connection Using  
            // Accept() method the server  
            // will accept connection of client 
            Socket clientSocket = listener.Accept();
            // Data buffer 
            byte[] bytes = new Byte[1024];
            string data = null;
            while (true)
            {
                int numByte = clientSocket.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes,
                                        0, numByte);
                if (data.IndexOf("<EOF>") > -1)
                    break;
            }
            Console.WriteLine("Text received -> {0} ", data);
            if (data == "<EOF> " + "kill")
            {
                break;
            }
            else if (data == "<EOF>" + "getpw")
            {
                sendtoclient(clientSocket, pwd);
            }
            else
            {
                sendtoclient(clientSocket, "Error 404 message not found!");
            }
            // Close client Socket using the 
            // Close() method. After closing, 
            // we can use the closed Socket  
            // for a new Client Connection 
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
    }
    catch (Exception e)
    {
        //Console.WriteLine(e.ToString());
    }
    closingAction();
}
And your `StartServer` would have to be adjusted a bit: 
private void StartServer() 
{
    Action closingAction = () => this.Close();
    Thread serverThread = new Thread(() => ExecuteServer("test", closingAction));
    serverThread.Start();
}
This will close the form once the server has ended. Of course you can change that action which is executed.  
Also the `shouldContinue` bool should look something like this:
private static volatile bool _shouldContinue = true;
You can of course exchange that for a property or whatever you want just set it to false if you want the loop to end.  
Last thing, keep in mind that if you're using blocking calls like `listener.Accept();` you will of course not cancel the thread straight away when changing the bool. For these things I would advise you to move away from blocking calls like this and try to find things with timeout for example.  
I hope you can start something with this.  
Good Luck!
