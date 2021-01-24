    private void richTextBox1_TextChanged(object sender, EventArgs e)
    {
        showLineNo();
    }
    private void richTextBox1_VScroll(object sender, EventArgs e)
    {
        showLineNo();
    }
    private void showLineNo()
    {
        // get current location
        Point p = this.richTextBox1.Location;
        int crntFirstIndex = this.richTextBox1.GetCharIndexFromPosition(p);
        int crntFirstLine = this.richTextBox1.GetLineFromCharIndex(crntFirstIndex);
        Point crntFirstPos = this.richTextBox1.GetPositionFromCharIndex(crntFirstIndex);
        p.Y += this.richTextBox1.Height;
        int crntLastIndex = this.richTextBox1.GetCharIndexFromPosition(p);
        int crntLastLine = this.richTextBox1.GetLineFromCharIndex(crntLastIndex);
        Point crntLastPos = this.richTextBox1.GetPositionFromCharIndex(crntLastIndex);
        // Set brush
        Graphics g = this.panel1.CreateGraphics();
        Font font = new Font(this.richTextBox1.Font, this.richTextBox1.Font.Style);
        SolidBrush brush = new SolidBrush(Color.Green);
        Rectangle rect = this.panel1.ClientRectangle;
        brush.Color = this.panel1.BackColor;
        g.FillRectangle(brush, 0, 0, this.panel1.ClientRectangle.Width, this.panel1.ClientRectangle.Height);
        brush.Color = Color.Black;
        // Draw line number
        int lineSpace = 0;
        if (crntFirstLine != crntLastLine)
        {
            lineSpace = (crntLastPos.Y - crntFirstPos.Y) / (crntLastLine - crntFirstLine);
        }
        else
        {
            lineSpace = Convert.ToInt32(this.richTextBox1.Font.Size);
        }
        int brushX = this.panel1.ClientRectangle.Width - Convert.ToInt32(font.Size * 3);
        int brushY = crntLastPos.Y + Convert.ToInt32(font.Size * 0.21f);
        for (int i = crntLastLine; i >= crntFirstLine; i--)
        {
            g.DrawString((i + 1).ToString(), font, brush, brushX, brushY);
            brushY -= lineSpace;
        }
        g.Dispose();
        font.Dispose();
        brush.Dispose();
    }
