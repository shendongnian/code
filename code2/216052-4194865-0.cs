    public class BaseControl : Control
    {
        private object _selected;
        public object Selected
        {
            get { return _selected; }
            set
            {
                if (!Equals(_selected, value))
                {
                    _selected = value;
                    OnSelectedChanged(EventArgs.Empty);
                }
            }
        }
        public event EventHandler SelectedChanged;
        protected virtual void OnSelectedChanged(EventArgs e)
        {
            if (SelectedChanged != null)
                SelectedChanged(this, e);
        }
    }
