    protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle Base = new Rectangle(0, 0, Width, Height);
    
            e.Graphics.Clear(BackColor);
    
            e.Graphics.FillRectangle(new SolidBrush(_BaseColor), Base);
            e.Graphics.DrawString("r", Font, new SolidBrush(TextColor), new Rectangle(0, 0, Width, Height), CenterSF); //-- X
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(30,(State == MouseState.Down) ? Color.Black : Color.White)), Base);
    
            ////Why are you creating a bitmap and drawing that?  You can't just draw on controls surface?
            //using (Bitmap B = new Bitmap(Width, Height))
            //using (Graphics _with3 = Graphics.FromImage(B))
            //{
            //    Rectangle Base = new Rectangle(0, 0, Width, Height);
    
            //    //Not going to tell the difference.  So, I disable them.
            //    //_with3.SmoothingMode = SmoothingMode.HighQuality;
            //    //_with3.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //    //_with3.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    
            //    _with3.Clear(BackColor);
    
            //    _with3.FillRectangle(new SolidBrush(_BaseColor), Base); //-- Base
    
            //    _with3.DrawString("r", Font, new SolidBrush(TextColor), new Rectangle(0, 0, Width, Height), CenterSF); //-- X
    
            //    _with3.FillRectangle(new SolidBrush(Color.FromArgb(30, ((State == MouseState.Over) ? Color.Black : Color.White))), Base); //-- Hover/down
    
            //    base.OnPaint(e);
            //    //e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //    e.Graphics.DrawImageUnscaled(B, 0, 0);
            //}
        }
