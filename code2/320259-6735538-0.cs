    public class ServerConfiguration : ConfigurationSection, IServerConfiguration
    {
        [ ConfigurationProperty( FOO, DefaultValue = "", IsRequired = false ) ]
        public string FOO
        {
            get { return (string)this[FOO]; }
            set { this[FOO] = value; }
        }
    }
    
    public interface IServerConfiguration
    {
        public string FOO { get; } //Unless I am updating the config in code I don't use set on the interface
    }
