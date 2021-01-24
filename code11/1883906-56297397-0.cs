    System.Windows.Forms.Timer marqueeTimer = new System.Windows.Forms.Timer();
    string marqueeText = string.Empty;
    float marqueePosition = 0f;
    float marqueeStep = 4f;
    private void form1_Load(object sender, EventArgs e)
    {
        marqueeText = lblMarquee.Text;
        lblMarquee.Text = string.Empty;
        marqueeTimer.Tick += (s, ev) => { this.lblMarquee.Invalidate(); };
        marqueeTimer.Interval = 100;
        marqueeTimer.Start();
    }
    private void lblMarquee_Paint(object sender, PaintEventArgs e)
    {
        var marquee = sender as Label;
        SizeF stringSize = e.Graphics.MeasureString(marqueeText, marquee.Font, -1, marqueeFormat);
        PointF stringLocation = new PointF(marqueePosition, (marquee.Height - stringSize.Height) / 2);
        stringLength = marquee.ClientRectangle.Width - stringLocation.X;
        e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        e.Graphics.DrawString(marqueeText, marquee.Font, Brushes.Black, stringLocation, marqueeFormat);
        if (marqueePosition >= marquee.ClientRectangle.Width) marqueePosition = 0f;
        if (stringSize.Width + stringLocation.X > marquee.ClientRectangle.Width) {
            PointF partialStringPos = new PointF(-stringLength, (marquee.Height - stringSize.Height) / 2);
            e.Graphics.DrawString(marqueeText, marquee.Font, Brushes.Black, partialStringPos, marqueeFormat);
        }
        marqueePosition += marqueeStep;
    }
