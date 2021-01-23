        public Collection<Application> Applications
        {
            get { return this._applications; }
            private set
            {
                this._applications = value;
                this.NotifyPropertyChanged(() => this.Applications);
            }
        }
