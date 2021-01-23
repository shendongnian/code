    protected override void OnPaint(PaintEventArgs e)
    {
        if (Visible)
        {
            Graphics gr = e.Graphics;
            Rectangle clipRectangle = new Rectangle(new Point(0, 0), this.Size);
            Size tSize = TextRenderer.MeasureText(Text, this.Font);
            Rectangle r1 = new Rectangle(0, (tSize.Height / 2), Width - 2, Height - tSize.Height / 2 - 2);
            Rectangle r2 = new Rectangle(0, 0, Width, Height);
            Rectangle textRect = new Rectangle(6, 0, tSize.Width, tSize.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddRectangle(r2);
            gp.AddRectangle(r1);
            gp.FillMode = FillMode.Alternate;
            gr.FillRectangle(new SolidBrush(Parent.BackColor), clipRectangle);
            LinearGradientBrush gradBrush;
            gradBrush = new LinearGradientBrush(clipRectangle, SystemColors.GradientInactiveCaption, SystemColors.InactiveCaptionText, LinearGradientMode.BackwardDiagonal);
            gr.FillPath(gradBrush, RoundedRectangle.Create(r1, 7));
            Pen borderPen = new Pen(BorderColor);
            gr.DrawPath(borderPen, RoundedRectangle.Create(r1, 7));
            gr.FillRectangle(gradBrush, textRect);
            gr.DrawRectangle(borderPen, textRect);
            gr.DrawString(Text, base.Font, new SolidBrush(ForeColor), 6, 0);
        }
    }
    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        if (this.BackColor == Color.Transparent)
            base.OnPaintBackground(pevent);
    }
