        private void PD_PrintPage(object sender, PrintPageEventArgs e)
        {
            PrintDocument p = (PrintDocument)sender;
            PrintFileDetail pfdWorkingOn = null;
            foreach (PrintFileDetail pfd in pfds)
            {
                if (pfd._PrintDoc.DocumentName == p.DocumentName)
                {
                    pfdWorkingOn = pfd;
                    break;
                }
            }
            float yPos = 0f;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            float linesPerPage = e.MarginBounds.Height / _TextFilePrintingFont.GetHeight(e.Graphics);
            
            while (count < linesPerPage)
            {
                line = pfdWorkingOn._TxtFileBeingPrinted.ReadLine();
                if (line == null)
                {
                    break;
                }
                yPos = topMargin + count * _TextFilePrintingFont.GetHeight(e.Graphics);
                e.Graphics.DrawString(line, _TextFilePrintingFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }
            if (line != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                pfdWorkingOn._TxtFileBeingPrinted.Dispose();
                pfdWorkingOn._TxtFileBeingPrinted = null;
            }
        }
