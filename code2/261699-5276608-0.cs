    public class ReadOnlyControl<T> : where T : UserControl {
        protected T inputControl;
        protected Label lblLabel;
        public bool IsReadOnly { get; set; }
        public string Value { get; set; }
        //in load of control or render, where ever
        inputControl.Visible = !IsReadOnly;
        lblLabel.Visible = IsReadOnly;
        inputControl.Value = Value;
        lblLabel.Value = Value;
    }
    
