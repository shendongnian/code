        private ImageSource _playImage;
        public ImageSource PlayImage
        {
            get { return _playImage; }
            set
            {
                _playImage = value;
                Notify("PlayImage");
            }
        }
        protected void Notify(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }
