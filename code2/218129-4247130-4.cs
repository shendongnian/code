    public enum Platform
    {
         Desktop,
         Web,
         Silverlight
    } // eo enum Platform
    public class TimerFactory
    {
        private class ObjectInfo
        {
            private string m_Assembly;
            private string m_Type;
 
            // ctor
            public ObjectInfo(string _assembly, string _type)
            {
                m_Assembly = _assembly;
                m_Type = _type;
            } // eo ctor
            public ITimer Create() {return(AppDomain.CurrentDomain.CreateInstanceAndUnwrap(m_Assembly, m_Type));}
        } // eo class ObjectInfo
        Dictionary<Platform, ObjectInfo> m_Types = new Dictionary<PlatForm, ObjectInfo>();
 
        public TimerFactory()
        {
            m_Types[Platform.Desktop] = new ObjectInfo("Desktop", "MyNamespace.DesktopTimer");
            m_Types[Platform.Silverlight] = new ObjectInfo("Silverlight", "MyNameSpace.SilverlightTimer");
            // ...
        } // eo ctor
        public ITimer Create()
        {
            // based on platform, create appropriate ObjectInfo
        } // eo Create
    } // eo class TimerFactory
