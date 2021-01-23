    public class TextBoxEx : TextBox
    {
        #region SelectionChanged Event
        
        public event EventHandler SelectionChanged;
        private int lastSelectionStart;
        private int lastSelectionLength;
        private string lastSelectedText;
        private void RaiseSelectionChanged()
        {
            if (this.SelectionStart != lastSelectionStart || this.SelectionLength != lastSelectionLength || this.SelectedText != lastSelectedText)
                OnSelectionChanged();
            lastSelectionStart = this.SelectionStart;
            lastSelectionLength = this.SelectionLength;
            lastSelectedText = this.SelectedText;
        }
        protected virtual void OnSelectionChanged()
        {
            var eh = SelectionChanged;
            if (eh != null)
            {
                eh(this, EventArgs.Empty);
            }
        }
        #endregion
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            RaiseSelectionChanged();
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            RaiseSelectionChanged();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            RaiseSelectionChanged();
        }
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            RaiseSelectionChanged();
        }
    }
