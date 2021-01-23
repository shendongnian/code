    class MyControl : System.Windows.Forms.PictureBox
        {
            public MyControl()
            {
                this.SetStyle(ControlStyles.DoubleBuffer |
                    ControlStyles.UserPaint |
                    ControlStyles.AllPaintingInWmPaint,
                    true);
            }
        }
 
   
