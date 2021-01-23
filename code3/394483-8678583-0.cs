    public class KeyEventArgs : EventArgs
    {
        // Fields
        private bool handled;
        private readonly Keys keyData;
        private bool suppressKeyPress;
    
        // Methods
        public KeyEventArgs(Keys keyData);
    
        // Properties
        public virtual bool Alt { get; }
        public bool Control { get; }
        public bool Handled { get; set; }
        public Keys KeyCode { get; }
        public Keys KeyData { get; }
        public int KeyValue { get; }
        public Keys Modifiers { get; }
        public virtual bool Shift { get; }
        public bool SuppressKeyPress { get; set; }
    }
