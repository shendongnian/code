    private void pnlText_Paint(object sender, PaintEventArgs e)
        {
            pnlText.Font = new Font("Calibri", 14, FontStyle.Regular);
            SizeF lineSize = new SizeF();
            paragraph = ""; // that should reset the paragraph variable between invocations
            for (int i = 0; i < DisplayText.Length; i++)
            {
                currentLine += DisplayText[i];
    
                lineSize = e.Graphics.MeasureString(currentLine, pnlText.Font);
                if (DisplayText[i].ToString() == " " && lineSize.Width >= 820)
                {
    
                    paragraph += currentLine + "\n";
                    currentLine = null;
    
                }
            }
            using (SolidBrush br = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString(paragraph, pnlText.Font, br, 5, 5);
            }
        }
