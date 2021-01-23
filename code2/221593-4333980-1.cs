    using System.Runtime.Remoting;
    using System.Runtime.Remoting.Channels;
    using System.Runtime.Remoting.Channels.Tcp;
    static class ServerProgram
    {        
        [STAThread]
        static void Main()
        {     
            ATSServer();     
        }    
        static void ATSServer()
        {        
            TcpChannel tcpChannel = new TcpChannel(7000);
            ChannelServices.RegisterChannel(tcpChannel);
            Type commonInterfaceType = Type.GetType("ATSRemoteControl");
            RemotingConfiguration.RegisterWellKnownServiceType(commonInterfaceType,
            "RemoteATSServer", WellKnownObjectMode.SingleCall);
        }
    }
    public interface ATSRemoteControlInterface
    {
        string yourRemoteMethod(string parameter);
    }      
    public class ATSRemoteControl : MarshalByRefObject, ATSRemoteControlInterface
    {
        public string yourRemoteMethod(string GamerMovementParameter)
            {
                string returnStatus = "GAME MOVEMENT LAUNCHED";
                Console.WriteLine("Enquiry for {0}", GamerMovementParameter);
                Console.WriteLine("Sending back status: {0}", returnStatus);
                return returnStatus;
            }
    }
    class ATSLauncherClient
    {
        static ATSRemoteControlInterface remoteObject;
        public static void RegisterServerConnection()
        {
            TcpChannel tcpChannel = new TcpChannel();
            ChannelServices.RegisterChannel(tcpChannel);
            Type requiredType = typeof(ATSRemoteControlInterface);
            //HERE YOU ADJUST THE REMOTE TCP/IP ADDRESS 
            //IMPLEMENT RETRIEVAL PROGRAMATICALLY RATHER THAN HARDCODING
            remoteObject = (ATSRemoteControlInterface)Activator.GetObject(requiredType,
            "tcp://localhost:7000/RemoteATSServer");
            string s = "";
            s = remoteObject.yourRemoteMethod("GamerMovement");  
        }
        public static void Launch(String GamerMovementParameter)
        {
            remoteObject.yourRemoteMethod(GamerMovementParameter);
        }
    }
