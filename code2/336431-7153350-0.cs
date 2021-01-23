    private object data;
    public object Data {
        get { return data;}
        set {
            if(value != data) {
                data = value;
                OnDataChanged();
            }
        }
    }
    protected virtual void OnDataChanged() {
        EventHandler handler = DataChanged;
        if(handler != null) handler(this, EventArgs.Empty);
    }
    public event EventHandler DataChanged;
