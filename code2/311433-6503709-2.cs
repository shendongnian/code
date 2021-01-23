    class QuartzConsumer {
        public delegate void DataChangedEventHandler();
        public event DataChangedEventHandler DataChanged;
        void OnTimer(..) {
            if (this.DataChanged != null) this.DataChanged();
        }
    }
    // in MainForm:
    var quartzConsumer = new QuartzConsumer(..);
    quartzConsumer.DataChanged += this.OnDataChanged;
    ...
    void OnDataChanged() {
        // update the grid
    }
