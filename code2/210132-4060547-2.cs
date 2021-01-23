    using System;
    using System.Windows.Forms;
    
    class Canvas : Panel {
        public Canvas() {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
    }
