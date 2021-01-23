    StringReader reader;
            int prov = 0;
    
            private void DocumentToPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
            {
    
    
                if (prov == 0)
                {
                    prov = 1;
                    reader = new StringReader(eintragRichTextBox.Text);
                }
    float LinesPerPage = 0;
                float YPosition = 0;
                int Count = 0;
                float LeftMargin = e.MarginBounds.Left;
                float TopMargin = e.MarginBounds.Top;
                string Line = null;
....
