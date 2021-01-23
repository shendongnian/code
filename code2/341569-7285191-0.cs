    public class DoubleBufferedPictureBox : PictureBox
    {
        /// <summary>
        /// Creates an instance of the DoubleBufferedPictureBox.
        /// </summary>
        public DoubleBufferedPictureBox() : base()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
        }
    }
