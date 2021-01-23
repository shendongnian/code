     if(printPage <= 0) {
       //First Page
       char[] param = { '\n' };
       linesPrinted = 0;
       if (pd.PrinterSettings.PrintRange == PrintRange.Selection)
       {
           lines = rtb.SelectedText.Split(param);
       }
       else
       {
           lines = rtb.Text.Split(param);
       }
      }
       int i = 0;
       char[] trimParam = { '\r' };
       foreach (string s in lines)
       {
           lines[i++] = s.TrimEnd(trimParam);
       }
       
       int x = e.MarginBounds.Left;
       int y = e.MarginBounds.Top;
       Brush brush = new SolidBrush(rtb.ForeColor);
    
       while (linesPrinted < lines.Length)
       {
           e.Graphics.DrawString(lines[linesPrinted++],
                rtb.Font, brush, x, y);
           y += 15;
           if (y >= e.MarginBounds.Bottom)
           {
               e.HasMorePages = true;
               printPage++;
               return;
           }
           else
           {
               e.HasMorePages = false;
           }
       }
