    class MyControl : Control {
        public event EventHandler ValueChanged {
            add {
                checked.CheckChanged += value;
            }
            remove {
                checked.CheckChanged -= value;
            }
        }
        private CheckBox checked;
        // ...
    }
