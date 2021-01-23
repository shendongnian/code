    public interface ISession
    {
        public ControlUsu user {get; set;}
        public OdbcConnection connection {get; set;}
        //Other properties and methods...
    }
