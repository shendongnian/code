    public class DataClient : ClientBase<Classes.IDataService>, Classes.IDataService
    {
        public DataClient(string connectToHost)
            : base(new NetTcpBinding(SecurityMode.Transport)
                {
                    PortSharingEnabled = true,
                    Security = new NetTcpSecurity()
                    {
                        Transport = new TcpTransportSecurity()
                        {
                            ClientCredentialType = TcpClientCredentialType.Windows
                        }
                    }
                },
                new EndpointAddress(string.Format("net.tcp://{0}:5555/MyService",connectToHost)))
        { }
        #region IDataService Members
        public Classes.Folder GetFolder(string entryID)
        {
            return Channel.GetFolder(entryID);
        }
        public Classes.IItem GetItem(string entryID)
        {
            return Channel.GetItem(entryID);
        }
        #endregion
    }
