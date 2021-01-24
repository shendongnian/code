    private void Init () {
        view = ((Activity)cx).LayoutInflater.Inflate(Resource.Layout.MyPage, this);
        eventsListAdapter?.Dispose();
        eventsListAdapter = new EventsAdapter(
            context,
            EventListDisplay.DefaultView,
            dateCurrentlyDisplayed);
        var myObserver = new MyDataSetObserver();
        eventsListAdapter.RegisterDataSetObserver(myObserver);
        
        myObserver.DataChanged += OnDataChanged;
    }
    private void Redraw () {
        // UPDATE ICON HERE
    }
    
    private void OnDataChanged(object sender, EventArgs e) {
        Redraw();
    }
    
    public class MyDataSetObserver : DataSetObserver
        {
            public override void OnChanged()
            {
                base.OnChanged();
                // To be honest, I don't know what int DataChanged wants.. so arbitrarily set it to 1.
                OnDataChanged(new DataChangedEventArgs() { DataChanged = 1, TimeChanged = DateTime.Now });
            }
    
            public event EventHandler DataChanged;
    
            protected virtual void OnDataChanged(EventArgs e)
            {
                EventHandler handler = DataChanged;
                handler?.Invoke(this, e);
            }
    
            public delegate void DataChangedEventHandler(object sender, DataChangedEventArgs e);
        public class DataChangedEventArgs : EventArgs
        {
            public int DataChanged { get; set; }
            public DateTime TimeChanged { get; set; }
        }
    }
