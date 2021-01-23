    public class DerivedDataSetWrapper : INotifyPropertyChanged
    {
        private bool _mainFile;
        public DerivedDataSetWrapper(DerivedDataSetClass dataSet)
        {
            this.DataSet = dataSet;
        }
 
        // I assume no notification will be needed upon DataSet change;
        // hence auto-property here
        public DerivedDataSetClass DataSet { get; private set; }
        public bool MainFile
        {
            get { return this._mainFile; }
            set
            {
                this._mainFile = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("MainFile"));
            }
        }
    }
