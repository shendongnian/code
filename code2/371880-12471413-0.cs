    public class UIBackgroundWorker : BackgroundWorker
    {
        private System.Windows.Threading.Dispatcher uiDispatcher;
        public SafeUIBackgroundWorker(System.Windows.Threading.Dispatcher uiDispatcher)
            : base()
        {
            if (uiDispatcher == null)
                throw new Exception("System.Windows.Threading.Dispatcher instance required while creating UIBackgroundWorker");
            else
                this.uiDispatcher = uiDispatcher;
        }
        protected override void OnProgressChanged(ProgressChangedEventArgs e)
        {
            if (uiDispatcher.CheckAccess())
                base.OnProgressChanged(e);
            else
                uiDispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => base.OnProgressChanged(e)));
        }
        protected override void OnRunWorkerCompleted(RunWorkerCompletedEventArgs e)
        {
            if (uiDispatcher.CheckAccess())
                base.OnRunWorkerCompleted(e);
            else
                uiDispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => base.OnRunWorkerCompleted(e)));
        }
    }
