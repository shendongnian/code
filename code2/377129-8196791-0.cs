     class CustomProgressBar : ProgressBar
     {
      public CustomProgressBar()
      {
       this.SetStyle(ControlStyles.UserPaint|ControlStyles.OptimizedDoubleBuffer|ControlStyles.DoubleBuffer, true);
       this.UpdateStyles();
      }
    
      protected override void OnPaint(PaintEventArgs e)
      {
       const int inset = 2;
       Rectangle rect = this.ClientRectangle;
    
       var offscreen = e.Graphics;
       if (ProgressBarRenderer.IsSupported){
        ProgressBarRenderer.DrawHorizontalBar(offscreen, rect);
       }
    
       rect.Inflate(new Size(-inset, -inset));  // Deflate inner rectangle
       rect.Width = Convert.ToInt32(Math.Round((rect.Width * ((double)this.Value / this.Maximum))));
       if (rect.Width == 0) rect.Width = 1;
       LinearGradientBrush brush = new LinearGradientBrush(rect,this.BackColor, this.ForeColor, LinearGradientMode.Vertical);
       offscreen.FillRectangle(brush, inset, inset, rect.Width, rect.Height);
       offscreen.DrawString(Value.ToString(), this.Font,Brushes.Black,rect);
      }
     }
