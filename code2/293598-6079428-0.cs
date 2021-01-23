    public class RadioButtonSwitch : INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        protected void RaiseCollectionChanged()
        {
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        IDictionary<string, bool> _options;
        public RadioButtonSwitch(IDictionary<string, bool> options)
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
                    RaiseCollectionChanged();
                }
                else
                    _options[a] = false;
            }
        }
    }
