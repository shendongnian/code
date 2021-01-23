    public class VerticalProgressBar : ProgressBar
    {
        protected override CreateParams CreateParams
        {
            get
            {
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
            Graphics dc = e.Graphics;
            if (this.Minimum == this.Maximum || (this.Value - Minimum) == 0)
                return;
            int width = this.Width;                                                                 // The bar width
            int height = (this.Value - this.Minimum) * this.Height / (this.Maximum - this.Minimum);	// The bar height
            int x = 2;			                // The bottom-left x pos of the bar (or upper left on upsidedown bar)
            int y = this.Height - 1;			// The bottom-left y pos of the bar (or upper left on upsidedown bar)
 
            int blockheight = width * 3 / 4;    // The height of the block
            if (this.RightToLeftLayout && this.RightToLeft == System.Windows.Forms.RightToLeft.No)
                for (int currentpos = 0; currentpos < height; currentpos += blockheight + 1)
                    dc.FillRectangle(new SolidBrush(this.ForeColor), x, currentpos, width, blockheight);
            else
                for (int currentpos = y; currentpos > y - height; currentpos -= blockheight + 1)
                    dc.FillRectangle(new SolidBrush(this.ForeColor), x, currentpos - blockheight, width, blockheight);
            base.OnPaint(e);
        }
    }
