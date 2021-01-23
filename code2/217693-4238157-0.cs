    public sealed class SingletonProxy
    {
        private static readonly Lazy<IInfusion> instance 
              = new Lazy<IInfusion>(XmlRpcProxyGen.Create<IInfusion>);
        public static IInfusion Instance
        {
            get { return instance.Value; }
        }
    }
