    public class TransparentPictureBox : System.Windows.Forms.PictureBox
    {
        /// <summary>
        /// Initialize new instance of this class.
        /// </summary>
        public TransparentPictureBox()
            : base()
        {
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.BackColor = Color.Transparent;
        }
    }
