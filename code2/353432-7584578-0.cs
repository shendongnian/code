    using System;
    using System.Windows.Forms;
    
    class MyPropertyGrid : PropertyGrid {
        protected override void OnSystemColorsChanged(EventArgs e) {
            // Do nothing
        }
    }
