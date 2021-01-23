    public byte R {
        get {return r;}
        set { SetRGB(value, G, B); }
    }
    public byte G {
        get {return g;}
        set { SetRGB(R, value, B); }
    }
