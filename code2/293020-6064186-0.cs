    public class AnyGroup : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        IDictionary<string, bool> _options;
        public AnyGroup(IDictionary<string, bool> options)
        {
            this._options = options;
        }
        public bool this[string a]
        {
            get
            {
                return _options[a];
            }
            set
            {
                if (value)
                {
                    var other = _options.Where(p => p.Key != a).Select(p => p.Key).ToArray();
                    foreach (string key in other)
                        _options[key] = false;
                    _options[a] = true;
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Item[]"));
                }
                else
                    _options[a] = false;                
            }
        }        
    }
