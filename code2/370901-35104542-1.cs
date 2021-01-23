    public class PbsContextConfig : DbConfiguration
    {
        public PbsContextConfig()
        {
            this.AddInterceptor(new HintInterceptor());
        }
    }
