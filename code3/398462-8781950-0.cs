    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false, Inherited=false)]
    public class PluginAttribute : Attribute
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
    }
    public interface IPlug
    {
        void Run(IWork work);
    }
    [Plugin(DisplayName="Sample Plugin", Description="Some Sample Plugin")]
    public class SamplePlug : IPlug
    {
        public void Run(IWork work) { ... }
    }
