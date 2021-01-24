    private IEnumerable<User> _userSource;
        public IEnumerable<User> UserSource {
            get { return _userSource; }
            set { SetProperty(ref _userSource, value); }
        }
