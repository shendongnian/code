     internal interface IConnectionProperties
     {
            string Name { get; }
            bool Enabled { get; }
     }
     internal class ConnectionProperties : IConnectionProperties
     {
            public string Name { get; set; } = "Default Name";
            public bool Enabled { get; set; } = false;
     }
    
    internal class Data
    {
        internal IConnectionProperties Connection {get;}
    }
