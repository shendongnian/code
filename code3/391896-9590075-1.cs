    public class ChangingComboBox : ComboBox
    {
        private int _index;
        private int _lastIndex;
        private bool _suppress;
        public event SelectionChangingEventHandler SelectionChanging;
        public new event SelectionChangedEventHandler SelectionChanged;
        public ChangingComboBox()
        {
            _index = -1;
            _lastIndex = 0;
            _suppress = false;
            base.SelectionChanged += InternalSelectionChanged;
        }
		
        private void InternalSelectionChanged(Object s, SelectionChangedEventArgs e)
        {
            var args = new SelectionChangingEventArgs();
            OnSelectionChanging(args);
            if(args.Cancel)
            {
                return;
            }
            OnSelectionChanged(e);
        }
		
        public new void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            if (_supress || SelectionChanged == null)
            {
                return;
            }
            // Recall the last value of _index before updating
            if (_index >= 0) { _lastIndex = _index; }
            _index = SelectedIndex;
            SelectionChanged(this, e); 
        }
        public void OnSelectionChanging(SelectionChangingEventArgs e)
        {
            if (_supress || SelectionChanging == null)
            {
                return;
            }
            // Invoke user event handler and revert to 
            // last selected index if user cancels the change
            SelectionChanging(this, e);
            if(e.Cancel)
            {
                _suppress = true;
                SelectedIndex = _lastIndex;
                _suppress = false;
            }
        }
    }
