    public class ExcelComAddIn : IDTExtensibility2
    {
        public ExcelComAddIn();
        protected string ProgId { get; }
        public virtual void OnAddInsUpdate(ref Array custom);
        public virtual void OnBeginShutdown(ref Array custom);
        public virtual void OnConnection(object Application, ext_ConnectMode ConnectMode, object AddInInst, ref Array custom);
        public virtual void OnDisconnection(ext_DisconnectMode RemoveMode, ref Array custom);
        public virtual void OnStartupComplete(ref Array custom);
    }
