        private bool _FirstTimeSet = false;
        private double _Max;
        public double Max 
        {
            get
            {
                return this._Max;
            }
            set
            {
                if (value >= _Min || _FirstTimeSet == false)
                {
                    this._FirstTimeSet = true;
                    this._Max = value;
                    this.NotifyPropertyChanged("Max");
                }
            }
        }
