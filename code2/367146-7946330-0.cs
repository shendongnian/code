            private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font1 = new Font("Arial", 10, FontStyle.Regular);
            //e.Graphics.DrawString(tabsProperties[tabsProperties.IndexOf(new TabProperties(this.tabControl1.SelectedIndex))].TabHtml, font1, Brushes.Black, 100, 100);
            
            int charactersOnPage = 0;
            int linesPerPage = 0;
            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, font1,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);
            // Draws the string within the bounds of the page
            e.Graphics.DrawString(stringToPrint, font1, Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);
            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);
            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);
        }
