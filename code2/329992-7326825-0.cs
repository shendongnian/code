    public class VerticalProgressBar : ProgressBar
    {
        protected override CreateParams CreateParams
        {
            get
            {
                // Avoid CA2122
                new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();  
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x04;
                return cp;
            }
        }
        public VerticalProgressBar()
        {
            // Enable OnPaint overriding
            this.SetStyle(ControlStyles.UserPaint, true);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (ProgressBarRenderer.IsSupported)
            {
                ProgressBarRenderer.DrawVerticalBar(e.Graphics, e.ClipRectangle);
                
                const int HORIZ_OFFSET = 3;
                const int VERT_OFFSET = 2;
                if (this.Minimum == this.Maximum || (this.Value - Minimum) == 0 ||
                        this.Height < 2 * VERT_OFFSET || this.Width < 2 * VERT_OFFSET)
                    return;
                int barHeight = (this.Value - this.Minimum) * this.Height / (this.Maximum - this.Minimum);
                barHeight = Math.Min(barHeight, this.Height - 2 * VERT_OFFSET);
                int barWidth = this.Width - 2 * HORIZ_OFFSET;
               
                if (this.RightToLeftLayout && this.RightToLeft == System.Windows.Forms.RightToLeft.No)
                {
                    ProgressBarRenderer.DrawVerticalChunks(e.Graphics,
                            new Rectangle(HORIZ_OFFSET, VERT_OFFSET, barWidth, barHeight));
                }
                else
                {
                    int blockHeight = 10;
                    int wholeBarHeight = Convert.ToInt32(barHeight / blockHeight) * blockHeight;
                    int wholeBarY = this.Height - wholeBarHeight - VERT_OFFSET;
                    int restBarHeight = barHeight % blockHeight;
                    int restBarY = this.Height - barHeight - VERT_OFFSET;
                    ProgressBarRenderer.DrawVerticalChunks(e.Graphics,
                        new Rectangle(HORIZ_OFFSET, wholeBarY, barWidth, wholeBarHeight));
                    ProgressBarRenderer.DrawVerticalChunks(e.Graphics,
                        new Rectangle(HORIZ_OFFSET, restBarY, barWidth, restBarHeight));
                }
            }
            base.OnPaint(e);
        }
    }
