    public static void Main()
    {
        UDPClass.UDPListenParameters threadParameters = new UDPClass.UDPListenParameters();
        threadParameters.UDPPort = 64000;
        threadParameters.OldClass = this.GetType();
    
        UDPClass clsUDP = new UDPClass();
        Thread clsUDPThread = new Thread(new ParameterizedThreadStart(clsUDP.UDPListen));
        
        clsUDPThread.Start(threadParameters);
    }
    
    public class UDPClass
    {
        public void UDPListen(object parameter)
        {
            UDPListenParameters parameters = (UDPListenParameters)parameter;
            // parameters.UDPPort
            // parameters.OldClass
        }
        
        public class UDPListenParameters
        {
            public int UDPPort;
            public Type OldClass;
        }
    }
