    public class Model :INotifyPropertyChanged
    {
      .... Implement interface ... 
    
      public double Opacity
      {
        get { return this._opacity; } 
        set {this._opacity = value; this.OnPropertyChanged("Opacity"); } 
      }
    }
