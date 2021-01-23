    class Control
    {
        public Boolean HasFocus { get; private set; }
        internal void NotifyGainedFocus()
        {
            this.HasFocus = true;
            this.DrawWithNiceBlueShininess = true;
        }
        internal void NotifyLostFocus()
        {
            this.HasFocus = false;
            this.DrawWithNiceBlueShininess = false;
        }
    }
    class User // or UIManager
    {
        public Control FocusedControl { get; private set; }
        public void SetFocusOn(Control control)
        {
            if (control != this.FocusedControl)
            {
                if (this.FocusedControl != null)
                    this.FocusedControl.NotifyLostFocus();
                this.FocusedControl = control;
                this.FocusedControl.NotifyGainedFocus();
            }
        }
    }
