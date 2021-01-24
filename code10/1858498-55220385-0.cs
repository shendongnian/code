    class Test
    {
        private bool isChecked;
        public bool IsChecked
        {
            get { return this.isChecked; }
            set
            {
                this.isChecked= value;
                this.OnPropertyChanged("IsChecked");
            }
        }
    }
