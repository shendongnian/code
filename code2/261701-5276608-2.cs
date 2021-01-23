    public class ReadOnlyControl<T> : UserControl where T : UserControl, ITextControl {
        protected T inputControl;
        protected Label lblLabel;
        public bool IsReadOnly { get; set; }
        public string Value { get; set; }
        //in load of control or render, where ever
        inputControl.Visible = !IsReadOnly;
        lblLabel.Visible = IsReadOnly;
        inputControl.Text = Value;
        lblLabel.Text = Value;
    }
    
