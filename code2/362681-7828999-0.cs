    [AOP]
    class Test : ContextBoundObject
    {     
        public void TestMethod()     
        {
            throw new Exception();
        }      
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class AOPAttribute : ContextAttribute
    {
        public AOPAttribute() : base("AOPAttribute") { }
        public override void GetPropertiesForNewContext(IConstructionCallMessage ctor)
        {
            ctor.ContextProperties.Add(new AOPProperty());
        }
        public override bool IsContextOK(Context ctx, IConstructionCallMessage ctorMsg)
        { 
            return false; 
        }
    }
    public class AOPProperty : IContextProperty, IContributeServerContextSink
    {
        public IMessageSink GetServerContextSink(IMessageSink nextSink)
        {
            return new AOPSink(nextSink);
        }
        public string Name { get { return "AOP"; } }
        public bool IsNewContextOK(Context ctx) { return true; }
        public void Freeze(Context ctx) { }
    }
    public class AOPSink : IMessageSink
    {
        public AOPSink(IMessageSink nextSink) { this.NextSink = nextSink; }
        public IMessageSink NextSink { get; private set; }
        public IMessage SyncProcessMessage(IMessage msg)
        {
            // inspect method+params by playing with 'msg' here
            IMessage m = NextSink.SyncProcessMessage(msg);
            // inspect returnval/exception by playing with 'm' here
            return m;
        }
        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            throw new NotSupportedException();
        }
    }
