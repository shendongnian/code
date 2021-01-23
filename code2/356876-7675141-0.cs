    public class Numbers : INotifyPropertyChanged
    {
        private double? _Max;
        public double Max
        {
            get
            {
                return _Max ?? 0;
            }
            set
            {
                if (value >= _Min || !_Max.HasValue)
                {
                    this._Max = value;
                    this.NotifyPropertyChanged("Max");
                }
            }
        }
        private double? _Min;
        public double Min
        {
            get
            {
                return this._Min ?? 0;
            }
            set
            {
                if (value <= Max || !_Min.HasValue)
                {
                    this._Min = value;
                    this.NotifyPropertyChanged("Min");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
