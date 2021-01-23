    private ImageSource imageDrawing;
    public ImageSource ImageDrawing
    {
        get { return imageDrawing; }
        set
        {
            imageDrawing = value;
            RaisePropertyChanged("ImageDrawing");
        }
    }
    private void RaisePropertyChanged(string propertyName)
    {
        if(PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
