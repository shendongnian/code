    class ImageSourceWrapper : ObservableObject
    {
        private ImageSource _image;
        public ImageSource Image
        {
            get { return _image; }
            set
            {
                if (value != _image)
                {
                    _image = value;
                    
                    RaiseOnPropertyChanged("Image");
                }
            }
        }
        public ImageSourceWrapper(ImageSource image)
        {
            Image = image;
        }
    }
