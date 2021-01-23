    abstract class DrawingObject : ObservableItem
    {
        Point mPosition;
        public Point Position
        {
            get { return mPosition; }
            set { SetProperty("Position", ref mPosition, value); }
        }
    
        String mLabelText;
        public String LabelText
        {
            get { return mLabelText; }
            set { SetProperty("LabelText", ref mLabelText, value); }
        }
    }
