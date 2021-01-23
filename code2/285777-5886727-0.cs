    public class MasterData
    {
        private string _state1;
    
        public string State1
        {
            get { return _state1; }
            set
            {
                _state1 = value;
                OnDataChanged();
            }
        }
    
        private string _state2;
    
        public string State2
        {
            get { return _state2; }
            set
            {
                _state2 = value;
                OnDataChanged();
            }
        }
    
        public event EventHandler DataChanged;
    
        private void OnDataChanged()
        {
            if(this.DataChanged != null)
            {
                OnDataChanged(this, EventArgs.Empty);
            }
        }
    }
