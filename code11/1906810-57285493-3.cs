    SqlDataReader dr = null;
    PrintDocument pdoc = null;
    int pageNr = 0;
    private void printButton_Click(object sender, EventArgs e)
    {
        // connect and open reader
        // ..
        // set up the print document..
        pdoc = new PrintDocument();
        pdoc.DocumentName = "Printer Test";
        pdoc.PrintPage += PrintDocument_PrintPage;
        // ..
        pageNr = 0;
        pdoc.Print();
        // close connection & reader..
    }
    private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
    {
        bool pageDone = false;
        pageNr++;
        if (pageNr > maxPage) return;  // optional
        while(dr.Read())
        {
            e.HasMorePages = true;  // we have more data
            // print stuff
            // ..
            // if each Read fills one page..:
            pageDone = true; // ..or else use condition like y > yMax
            if (pageDone) return;  // return to print next page
        }
    }
