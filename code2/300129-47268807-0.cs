    public partial class SampleContext : DbContext
    {
        public SampleContext()
            : base("name=SampleContext")
        {
            this.SetCommandTimeOut(180);
        }
        public void SetCommandTimeOut(int Timeout)
        {
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = Timeout;
        }
