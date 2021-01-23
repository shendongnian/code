    public class XNAAsyncDispatcher : IApplicationService
    {
        private readonly DispatcherTimer _frameworkDispatcherTimer;
        public XNAAsyncDispatcher(TimeSpan dispatchInterval)
        {
            _frameworkDispatcherTimer = new DispatcherTimer();
            _frameworkDispatcherTimer.Tick += frameworkDispatcherTimer_Tick;
            _frameworkDispatcherTimer.Interval = dispatchInterval;
        }
        void IApplicationService.StartService(ApplicationServiceContext context) { _frameworkDispatcherTimer.Start(); }
        void IApplicationService.StopService() { _frameworkDispatcherTimer.Stop(); }
        void frameworkDispatcherTimer_Tick(object sender, EventArgs e) { FrameworkDispatcher.Update(); }
    }
