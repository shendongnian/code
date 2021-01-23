    public override Image BackgroundImage {
        get { return base.BackgroundImage; }
        set {
            base.BackgroundImage = value;
            if (value != null) this.Size = value.Size;
        }
    }
