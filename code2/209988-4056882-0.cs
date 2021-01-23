    public class GroupBoxEx : GroupBox
    {
        SizeF sizeOfText;
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            CalculateTextSize();            
        }
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            CalculateTextSize();
        }
        protected void CalculateTextSize()
        {
            // measure the string:
            using (Graphics g = this.CreateGraphics())
            {
                sizeOfText = g.MeasureString(Text, Font);
            }
            linePen = new Pen(Color.FromArgb(86, 136, 186), sizeOfText.Height * 0.1F);
        }
        Pen linePen;
        
        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw the string, we now have complete control over where:
            
            Rectangle r = new Rectangle(ClientRectangle.Left + Margin.Left, 
                ClientRectangle.Top + Margin.Top, 
                ClientRectangle.Width - Margin.Left - Margin.Right, 
                ClientRectangle.Height - Margin.Top - Margin.Bottom);
            
            const int gapInLine = 2;
            const int textMarginLeft = 7, textMarginTop = 2;
            // Top line:
            e.Graphics.DrawLine(linePen, r.Left, r.Top, r.Left + textMarginLeft - gapInLine, r.Top);
            e.Graphics.DrawLine(linePen, r.Left + textMarginLeft + sizeOfText.Width, r.Top, r.Right, r.Top);
            // and so on...
            // Now, draw the string at the desired location:            
            e.Graphics.DrawString(Text, Font, Brushes.Black, new Point(this.ClientRectangle.Left + textMarginLeft, this.ClientRectangle.Top - textMarginTop));
        }
    }
