    SqlDataReader dr = null;
    PrintDocument pdoc = null;
    private void button3_Click(object sender, EventArgs e)
    {
        // connect and open reader
        // ..
        // set up the print document..
        pdoc = new PrintDocument();
        pdoc.DocumentName = "Printer Test";
        pdoc.PrintPage += PrintDocument_PrintPage;
            // ..
        // ..
        pdoc.Print();
    }
    private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
    {
        bool pageDone = false;
        while(dr.Read())
        {
            e.HasMorePages = true;  // we have more data
            // print stuff
            // ..
            // ..
            pageDone = true; // or condition like y > yMax
            if (pageDone) return;  // return to print next page
        }
    }
