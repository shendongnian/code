        public MyClass SomeName
        {
            get
            {
                return this._SomeName;
            }
            set
            {
                if (value != this._SomeName)
                {
                    this._SomeName = value;
                    this.RaisePropertyChanged("SomeName");
                }
            }
        }
        private MyClass _SomeName;
