        public class FormShower : MarshalByRefObject
    {     
        /// <summary>
        /// For remote calls.
        /// </summary>
        public void Show()
        {
            if (FormShower.m == null)
                throw new ApplicationException("Could not use remoting to show Main form because the reference is not set in the FormShower class.");
            else
                FormShower.m.Invoke(FormShower.m.ShowFromFormShower);
        }
        private const int PortNumber = 12312;
        private static Main m = null;
        public delegate void ShowFromFormShowerDelegate();
        internal static void Register(Main m)
        {
            if (m == null) throw new ArgumentNullException("m");
            FormShower.m = m;
            ChannelServices.RegisterChannel(new TcpChannel(FormShower.PortNumber), false);            
            RemotingConfiguration.RegisterActivatedServiceType(typeof(FormShower));
        }
        internal static void CallShow()
        {
            TcpClientChannel c = new TcpClientChannel();
            ChannelServices.RegisterChannel(c, false);
            RemotingConfiguration.RegisterActivatedClientType(typeof(FormShower), "tcp://localhost:"+PortNumber.ToString());
            FormShower fs = new FormShower();
            fs.Show();
        }
    }
