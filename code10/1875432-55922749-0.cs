    public abstract class BaseCalculator 
    {
        private readonly IVersion _version;
        protected BaseCalculator()
        {
        }
        public void Calculate(Request r)
        {
            this._version = GetVersion();
            CalculateInternal();
            //version code here
        }
        protected virtual void GetVersion() //protected virtual or abstract, pick the best for your scenario.
        {
            return new Version(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
        }
        protected abstract void CalculateInternal(Request r);
        public abstract StatisticsModel Calculate(StatisticsRequest model);
    }
