        protected PremiseProperty<String> _DisplayName = new PremiseProperty<String>("DisplayName");
        public string DisplayName
        {
            get
            {
                return _DisplayName.Value;
            }
            set
            {
                if (_DisplayName.Value == value)
                {
                    return;
                }
                var oldValue = _DisplayName;
                _DisplayName.Value = value;
                // Update bindings and sendToServer change using GalaSoft.MvvmLight.Messenging
                RaisePropertyChanged(_DisplayName.PropertyName, 
                       oldValue, _DisplayName, _DisplayName.UpdatedFromServer);
            }
        }
