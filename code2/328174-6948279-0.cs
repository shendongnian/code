    [DataContract]
    public class ConfigurationInfo
    {
        [DataMember]
        public string Foo;
        ...
        // This string is a json/xml blob specific to the 'svcType' parameter
        [DataMember]
        public string ServiceConfig;
    }
    [DataContract]
    public interface IServiceHost
    {
        ConfigurationInfo GetConfigurationData(string svcType);
    }
