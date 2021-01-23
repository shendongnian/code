    private void printButton_Click(Object sender, EventArgs e)
    {
        PrintDocument doc = New PrintDocument();
        doc.PrintPage += new PrintPageEventHandler(printPage);
        doc.Print();
    }
    
    private void printPage(Object sender, PrintPageEventArgs e)
    {
        string printText = myTextbox.Text;
        Font printFont = myTextbox.Font;
        e.Graphics.DrawString(printText, printFont, Brushes.Black, e.MarginBounds.X, e.MarginBounds.Y);
    }
