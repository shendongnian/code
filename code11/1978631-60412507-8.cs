    private ImageSource img;
        public ImageSource Img
        {
            get { return img; }
            set
            {
                img = value;
                OnPropertyChanged();
            }
        }
    private UserDTO Obj;
        public UserDTO obj
        {
            get { return Obj; }
            set
            {
                Obj = value;
                OnPropertyChanged();
            }
        }
