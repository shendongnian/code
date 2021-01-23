    using System.Drawing;
    using System.Drawing.Drawing2D;
    private void Form1_Paint(object sender, PaintEventArgs e) {
      using (var lgb = new LinearGradientBrush(this.ClientRectangle, Color.Yellow, Color.Green, LinearGradientMode.Vertical))
        e.Graphics.FillRectangle(lgb, this.ClientRectangle);
    }
    private void Form1_Resize(object sender, EventArgs e) {
      this.Invalidate();
    }
