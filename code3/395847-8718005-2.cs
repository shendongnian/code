    public class MyClass : INotifyPropertyChanged
    {
      public event PropertyChangedEventHandler PropertyChanged;
      private void NotifyPropertyChanged(String property)
      {
        var event = this.PropertyChanged;
        if (event != null)
        {
          event(this, new PropertyChangedEventArgs(property));
        }
      }
      private float _inverseMass;
      public float inverseMass
      {
        get { return this._inverseMass; }
        set { this._inverseMass = value; NotifyPropertyChanged("inverseMass"); }
      }
    }
