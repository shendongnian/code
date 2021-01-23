    public interface IPlugin
    {
        PluginResult Execute(Object parameters);
    }
    public class PingParameters
    {
        //Various parameters here, including [Description] and [DisplayName] attributes if you wish
    }
    public class ParametersTypeAttribute : Attribute
    {
        public Type Type { get; private set; }
        public ParametersTypeAttribute(Type type)
        {
            Type = type;
        }
    }
    [ParametersType(typeof(PingParameters))]
    public class PingPlugin : IPlugin
    {
        public PluginResult Execute(Object parameters)
        {
            return Execute((PingParameters) parameters);
        }
        private PluginResult Execute(PingParameters parameters)
        {
            //Your execution code here
        }
    }
