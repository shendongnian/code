    int charactersOnPage = 0;
    int linesPerPage = 0;
    // Sets the value of charactersOnPage to the number of characters 
    // of stringToPrint that will fit within the bounds of the page.
    e.Graphics.MeasureString(stringToPrint, this.Font,
        e.MarginBounds.Size, StringFormat.GenericTypographic,
        out charactersOnPage, out linesPerPage);
    // Draws the string within the bounds of the page
    e.Graphics.DrawString(stringToPrint, this.Font, Brushes.Black,
        e.MarginBounds, StringFormat.GenericTypographic);
    // Remove the portion of the string that has been printed.
    if (stringToPrint.Length > charactersOnPage)
    {
    stringToPrint = stringToPrint.Substring(charctersOnPage);
    }
    // Check to see if more pages are to be printed.
    e.HasMorePages = (stringToPrint.Length > 0);
