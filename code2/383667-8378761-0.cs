    using System;
    using System.Windows.Forms;
    
    class BufferedListView : ListView {
        public BufferedListView() {
            this.DoubleBuffered = true;
        }
    }
