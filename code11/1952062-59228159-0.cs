        private string test;
        public string Test
        {
            get { return this.test; }
            set
            {
                if (this.test != value)
                {
                    this.test = value;
                    this.NotifyPropertyChanged("Test");
                    this.NotifyPropertyChanged("MyButtonCanExecute");
                }
            }
        }
