    // bad code
    class MyControl : Control {
        public event EventHandler ValueChanged;
        private CheckBox checked;
        // ...
        
        private void InitializeComponent() {
            // ...
            checked.CheckedChanged += checked_CheckedChanged;
            // ...
        }
        private void checked_CheckedChanged(object sender, EventArgs e) {
            if (ValueChanged != null) {
                ValueChanged(sender, e);
            }
        }
    }
