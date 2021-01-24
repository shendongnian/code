    namespace App.Models
    {
    public class ConfigModel : INotifyPropertyChanged
    {
        private bool _showConfig;
        public event PropertyChangedEventHandler PropertyChanged;
        public bool ShowConfig
        {
            get { return this._showConfig; }
            set
            {
                this._showConfig = value;
                this.OnPropertyChanged("ShowConfig");
            }
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
