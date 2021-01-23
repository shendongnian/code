    public MyModel Model { get; private set; }
    public MyViewModel() {
        Model = new MyModel();
        Model.PropertyChanged += (s,e) => SomethingChangedInModel(e.PropertyName);
    }
    private HashSet<string> _propertyChanges = new HashSet<string>();
    public void SomethingChangedInModel(string propertyName) {
        lock (_propertyChanges) {
            if (_propertyChanges.Count == 0)
                _timer.Start();
            _propertyChanges.Add(propertyName ?? "");
        }
    }
    // this is connected to the DispatherTimer
    private void TimerCallback(object sender, EventArgs e) {
        List<string> changes = null;
        lock (_propertyChanges) {
            _Timer.Stop(); // doing this in callback is safe and disables timer
            if (!_propertyChanges.Contain(""))
                changes = new List<string>(_propertyChanges);
            _propertyChanges.Clear();
        }
        if (changes == null)
            OnPropertyChange(null);
        else
            foreach (string property in changes)
                OnPropertyChanged(property);
    }
