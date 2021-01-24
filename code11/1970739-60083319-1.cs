        public string FirstName
        {
            get => _firstName; 
            set
            {
                if (_firstName == value) return;
                _firstName = value;
                OnPropertyChanged(); 
            }
        }
