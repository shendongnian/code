    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
     {
       e.Graphics.DrawImage(capturebox.BackgroundImage, 0, 0);
       e.DrawString(ExtraNotes.Text, SystemFonts.CaptionFont, Brushes.Black, 10, 10);
       e.Graphics.DrawImage(capturebox.Image, 0, 0);    
     }
