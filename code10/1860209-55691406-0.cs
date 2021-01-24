    internal sealed class ApplicationService
    {
        private ApplicationService() { }
        private static readonly ApplicationService _instance = new ApplicationService();
        internal static ApplicationService Instance { get { return _instance; } }
        private Prisms.IEventAggregator _eventAggregator;
        internal Prisms.IEventAggregator EventAggregator
        {
            get
            {
                if (_eventAggregator == null)
                {
                    _eventAggregator = new Prisms.EventAggregator();
                }
                
                return _eventAggregator;
            }
        }
