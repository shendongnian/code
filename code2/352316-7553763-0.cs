    using System;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace CustomPX
    {
        public class CustomPictureBox : PictureBox
        {
            public event EventHandler ImageChanged;
            public Image Image
            {
                get
                {
                    return base.Image;
                }
                set
                {
                    base.Image = value;
                    if (this.ImageChanged != null)
                        this.ImageChanged(this, new EventArgs());
                }
            }
        }
    }
