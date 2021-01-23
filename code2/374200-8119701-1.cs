      private void btnPageSetup_Click(object sender, System.EventArgs e)
      {
        PageSetupDialog psd = new PageSetupDialog();
        psd.Document = printDocument;
        psd.ShowDialog();
      }
    
      private void btnPrint_Click(object sender, System.EventArgs e)
      {
        PrintDialog pdlg = new PrintDialog();
        pdlg.Document = printDocument;
        
        if (pdlg.ShowDialog() == DialogResult.OK)
        {
          try
          {
            printDocument.Print();
          }
          catch(Exception ex)
          {
            MessageBox.Show("Print error: " + ex.Message);
          }
        }
      }
    
      private void btnPrintPreview_Click(object sender, System.EventArgs e)
      {
        PrintPreviewDialog ppdlg = new PrintPreviewDialog();
        ppdlg.Document = printDocument;
        ppdlg.ShowDialog();
      }
    
      private void pdPrintPage(object sender, PrintPageEventArgs e)
      {
        float linesPerPage = 0;
        float verticalOffset = 0;
        float leftMargin = e.MarginBounds.Left;
        float topMargin = e.MarginBounds.Top;
        int linesPrinted = 0;
        String strLine = null;
    
        linesPerPage = e.MarginBounds.Height / currentFont.GetHeight(e.Graphics);
        
        while (linesPrinted < linesPerPage &&
            ((strLine = stringReader.ReadLine())!= null ))
        {
          verticalOffset = topMargin + (linesPrinted * currentFont.GetHeight(e.Graphics));
          e.Graphics.DrawString(strLine, currentFont, Brushes.Black, leftMargin, verticalOffset);
          linesPrinted++;
        }
        
        if (strLine != null)
          e.HasMorePages = true;
        else
          e.HasMorePages = false;
          
      }
    
      private void pdBeginPrint(object sender, PrintEventArgs e)
      {
        stringReader = new StringReader(txtFile.Text);
        currentFont = txtFile.Font;
      }
    
      private void pdEndPrint(object sender, PrintEventArgs e)
      {
        stringReader.Close();
        MessageBox.Show("Done printing.");
      }
    }
