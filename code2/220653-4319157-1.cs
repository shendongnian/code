    public class FindCompaniesCompletedEventArgs : EventArgs
    {
        private List<TaxiCompany> _results;
        public List<TaxiCompany> Results
        {
            get
            {
                if (Error != null)
                    throw Error;
                return _results;
            }
        }
        public Exception Error { get; private set; }
        public FindCompaniesCompletedEventArgs(List<TaxiCompany> results)
        {
            _results = results;
        }
        public FindCompaniesCompletedEventArgs(Exception error)
        {
            Error = error;
        }
    }
