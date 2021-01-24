    interface IConnectionProperties
    {
        public string Name { get; }
        public bool Enabled { get; }
    }
    public class ConnectionProperties : IConnectionProperties
    {
        public string Name { get; internal set; } = "Default Name";
        public bool Enabled { get; internal set; } = false;
    }
    
    internal class Data
    {
        public IConnectionProperties Connection { get; set; }
        internal Data()
        {
            var connection = new ConnectionProperties();
            // Business logic to configure connection
            connection.Name = "My Connection";
            connection.Enabled = true;
            Connection = connection;
        }
    }
