    public class Program
        {
            public static void Main(string[] args)
            {
                var data = new Data();
                var c = new ConnectionProperties("", false);
                data.Connection.Name = ""; // prints readonly error
                data.Connection = new ConnectionProperties("", false); //prints readonly error
                data.Connection = c; //prints readonly error
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
            public ConnectionProperties Connection => new ConnectionProperties("My Connection", true);
    
            internal Data()
            {
            }
        }
