    class ImageProperties {      
      public int BrightnessPercentage { get; set; }
    }
    
    class ImageDrawer {
      public int BrightnessPercentage { get; set; }
    }
    
    ImageProperties _imgProps = new ImageProperties();
    ImageDrawer _imgDrawer = new ImageDrawer();
    
    public int TheBrightnessPercentage {
      get { return _imgProps.BrightnessPercentage;}
      set { _imgProps.BrightnessPercentage=_imgDrawer.BrightnessPercentage=value;}
    }
    void Test() {
        trackBar1.DataBindings.Add("Value", this, "TheBrightnessPercentage", false, DataSourceUpdateMode.OnPropertyChanged);    
    }
