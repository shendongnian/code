    using System;
    using System.Windows.Forms;
    
    class MyPictureBox : PictureBox {
        public MyPictureBox() {
            this.SetStyle(ControlStyles.StandardDoubleClick, false);
        }
    }
