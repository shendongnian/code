    public class Program
        {
            public static void Main(string[] args)
            {
                var data = new Data();
                data.Connection.Name = ""; // prints readonly error
            }
        }
    
        internal class ConnectionProperties
        {
            internal ConnectionProperties(string name, bool enabled)
            {
                Name = name;
                Enabled = enabled;
            }
            internal string Name { get; } = "Default Value";
            internal bool Enabled { get; } = false;
        }
        internal class Data
        {
            public ConnectionProperties Connection => new ConnectionProperties("some", true);
    
            internal Data()
            {
            }
        }
