    private Image mImage;
    public Image Image {
        get { return mImage; }
        set { 
            mImage = value;
            Invalidate();
        }
    }
