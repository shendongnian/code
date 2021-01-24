    class CustomPictureBox : PictureBox
    {
        public CustomPictureBox() {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
    // change the type of spiller in Form1.designer.cs
    System.Windows.Forms.PictureBox spiller;
    // becomes
    CustomPictureBox spiller;
    // and
    spiller = new System.Windows.Forms.PictureBox();
    // becomes
    spiller = new CustomPictureBox();
