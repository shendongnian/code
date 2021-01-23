    /// <summary>
    /// A custom job factory that is aware of the spring context
    /// </summary>
    public class ContextAwareJobFactory : AdaptableJobFactory, IApplicationContextAware
    {
        /// <summary>
        /// The spring app context
        /// </summary>
        private IApplicationContext m_Context;
        /// <summary>
        /// Set the context
        /// </summary>
        public IApplicationContext ApplicationContext
        {
            set
            {
                m_Context = value;
            }
        }
        /// <summary>
        /// Overrides the default version and sets the context
        /// </summary>
        /// <param name="bundle"></param>
        /// <returns></returns>
        protected override object CreateJobInstance(TriggerFiredBundle bundle)
        {
            return m_Context.GetObject(bundle.JobDetail.JobType.Name, bundle.JobDetail.JobType);
        }
    }
