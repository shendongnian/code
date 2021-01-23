    private ObservableCollectin<SItem2> pushPins;
    public ObservableCollection<SItem2> PushPins
    {
      get { return this.pushPins; }
      set
      {
        this.pushPins = value;
        this.OnPropertyChanged("PushPins");
      }
    }
    public void GetItems()
    {
      ...
      this.PushPins = new ObservableCollection<SItem2>();
      foreach (var ev in events)
      {
        var pushPin = new SItem2(ev.Latitude, ev.Longitude);
        this.PushPins.Add(pushPin);
      }
    }
