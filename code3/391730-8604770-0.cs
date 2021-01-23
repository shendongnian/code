        public global::System.String Property
        {
            get
            {
                return _Property;
            }
            set
            {
                OnPropertyChanging(value);
                ReportPropertyChanging("Property");
                _Property = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Property");
                OnPropertyChanged();
            }
        }
        private global::System.String _Property;
        partial void OnPropertyChanging(global::System.String value);
        partial void OnPropertyChanged();
