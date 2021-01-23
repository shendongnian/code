    using System;
    using System.Windows.Forms;
    
    class MyPanel : Panel {
        public MyPanel() {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
    }
