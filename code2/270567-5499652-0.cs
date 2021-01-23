    public class ReportHeader
    {
        private TextLine[] textLines
        
        ...
        public TextLine[] TextLines
        {
            get { return this.textLines; }
        }
        ...
    }
    public Control returnTextLine(ReportHeader reportHeader, int textLineIndex)
    {
        TextLine textLine = reportHeader.TextLines[textLineIndex];
        System.Windows.Forms.Label lblTextLine = new System.Windows.Forms.Label();
        lblTextLine.Name = textLine.Name;
        lblTextLine.Font = textLine.Font;
        lblTextLine.ForeColor = textLine.ForeColor;
        lblTextLine.BackColor = textLine.BackgroundColor;
        lblTextLine.Text = textLine.Text;
        int x = textLine.x;
        int y = textLine.y;
        lblTextLine.Location = new Point(x, y);
        return lblTextLine;
    }
