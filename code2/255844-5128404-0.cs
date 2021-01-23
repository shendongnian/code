    using System;
    using System.Windows.Forms;
    
    class MyControl : Control {
        public event EventHandler AllowDropChanged;
    
        protected void OnAllowDropChanged(EventArgs e) {
            var handler = AllowDropChanged;
            if (handler != null) handler(this, e);
        }
    
        public override bool AllowDrop {
            get { return base.AllowDrop; }
            set {
                if (value != base.AllowDrop) {
                    base.AllowDrop = value;
                    OnAllowDropChanged(EventArgs.Empty);
                }
            }
        }
    }
