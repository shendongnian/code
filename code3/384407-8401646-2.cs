        public Application SelectedApplication
        {
            get { return this._selectedApplication; }
            set
            {
                this._selectedApplication = value;
                this.NotifyPropertyChanged(() => this.SelectedApplication);
            }
        }
