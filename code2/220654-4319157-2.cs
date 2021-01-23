    public class TaxiCompanyFinder
    {
        protected void OnFindCompaniesCompleted(FindCompaniesCompletedEventArgs e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() => FindCompaniesCompleted(this, e));
        }
        public event EventHandler<FindCompaniesCompletedEventArgs> FindCompaniesCompleted = delegate {};
        public void FindCompaniesAsync()
        {
            // The real work here
        }
    }
 
