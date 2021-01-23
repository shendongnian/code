    //Use this class when you have HttpSessionState
    public class ProgramHttpSession : ISession
    {
        public ControlUsu user
        {
            get {return (ControlUsu)Session["currentuser"];}
            set {Session["currentuser"] = value;}
        }
        public OdbcConnection connection
        {
            get {return (OdbcConnection)Session["currentconnection"];}
            set {Session["currentconnection"] = value;}
        }
    }
    //Use this class when you DON'T have HttpSessionState (like in threads)
    public class ProgramSession : ISession
    {
        private ControlUsu theUser;
        public ControlUsu user
        {
            get {return theUser;}
            set {theUser = value;}
        }
        private OdbcConnection theConnection;
        public OdbcConnection connection
        {
            get {return theConnection;}
            set {theConnection = value;}
        }
        public ProgramSession(ControlUsu aUser, OdbcConnection aConnection)
        {
            theUser = aUser;
            theConnection = aConnection;
        }
    }
