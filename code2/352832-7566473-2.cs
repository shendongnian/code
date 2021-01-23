    interface IFocusChecker
    {
        bool HasFocus(Control control);
    }
    class Manager : IFocusChecker
    {
        private Control _focusedControl;
        public void SetFocus(Control control)
        {            
            _focusedControl = control;
        }
        public bool HasFocus(Control control)
        {
            return _focusedControl == control;
        }
    }
    class Control
    {
        private IFocusChecker _checker;
        public Control(IFocusChecker checker)
        {
            _checker = checker;
        }
        public bool HasFocus()
        {
            return _checker.HasFocus(this);
        }
    }
