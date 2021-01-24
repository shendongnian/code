    private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            float printAreaHeight = ev.MarginBounds.Height;
            float printAreaWidth = ev.MarginBounds.Width;
            string line = null;
            float yPos = topMargin;
            int charactersFitted = 0;
            int linesFilled = 0;
            SizeF theSize = new SizeF();
            Font printFont = new Font("Arial", 12, FontStyle.Regular);
            
            SizeF layoutSize = new SizeF(printAreaWidth, printAreaHeight);
            // Calculate the number of lines per page.
            linesPerPage = printAreaHeight / printFont.GetHeight(ev.Graphics);
            // Print each line of the array.
            while (count < linesPerPage && lineIdx < linesArray.Count())
            {
                line = linesArray[lineIdx++];
                theSize = ev.Graphics.MeasureString(line, printFont, layoutSize, new StringFormat(), out charactersFitted, out linesFilled);
                ev.Graphics.DrawString(line, printFont, Brushes.Black, new RectangleF(50.0F, yPos, theSize.Width, theSize.Height));
                yPos += (1 + linesFilled) * printFont.GetHeight(ev.Graphics);
                count += linesFilled + 1;
             }
             // If more lines exist, print another page.
             if (count > linesPerPage)
                ev.HasMorePages = true;
             else
                ev.HasMorePages = false;
        }
