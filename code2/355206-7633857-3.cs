    class Program
    {
        static void Main(string[] args)
        {
            InitializeRemoting();
            var remote = GetRemotingObject("localhost");
            var local = new LocalClass();
            remote.SomeMethod();
            local.SomeMethod();
            Console.ReadLine();
        }
        static void InitializeRemoting()
        {
            var c = new TcpServerChannel(9000);
            ChannelServices.RegisterChannel(c, false);
            WellKnownServiceTypeEntry entry = new WellKnownServiceTypeEntry
            (
                typeof(RemoteClass),
                "LocalClass", // Lie about the object name.
                WellKnownObjectMode.Singleton
            );
            RemotingConfiguration.RegisterWellKnownServiceType(entry);
        }
        static LocalClass GetRemotingObject(string serverName)
        {
            TcpClientChannel channel = new TcpClientChannel("tcp-client", new BinaryClientFormatterSinkProvider());
            ChannelServices.RegisterChannel(channel, false);
            return (LocalClass)Activator.GetObject
            (
                typeof(LocalClass), // Remoting will happily cast it to a type we have access to.
                string.Format("tcp://{0}:9000/LocalClass", serverName)
            );
        }
    }
    public class LocalClass : MarshalByRefObject
    {
        public void SomeMethod()
        {
            OnSomeMethod();
        }
        protected virtual void OnSomeMethod()
        {
            // Method called locally.
            Console.WriteLine("Local!");
        }
    }
    // Note that we don't need to (and probably shouldn't) expose the remoting type publicly.
    class RemoteClass : LocalClass
    {
        protected override void OnSomeMethod()
        {
            // Method called remotely.
            Console.WriteLine("Remote!");
        }
    }
    // Output:
    // Remote!
    // Local!
