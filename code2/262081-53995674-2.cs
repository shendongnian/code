    // ----------------------------------------------------------------------------------------------
    // If you run this on Windows 10 (having it's default printer "Microsoft Print to PDF" installed)
    // This should print a PDF file named "CreatedByCSharp.PDF" in your "MyDocuments" folder
    // containing the string "When nothing goes right, go left"
    // ----------------------------------------------------------------------------------------------
    
    // If not present, you will need to add a reference to System.Drawing in your project References
    using System.Drawing;
    using System.Drawing.Printing;
    
    
    void PrintPDF()
    {
        // Set the output dir and file name
        string directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string file = "CreatedByCSharp.pdf";
    
        PrintDocument pDoc = new PrintDocument()
        {
            PrinterSettings = new PrinterSettings()
            {
                 PrinterName = "Microsoft Print to PDF", 
                 PrintToFile = true, 
                 PrintFileName = System.IO.Path.Combine(directory, file),
            }
        };
    
        pDoc.PrintPage += new PrintPageEventHandler(Print_Page);
        pDoc.Print();
    }
    
    void Print_Page(object sender, PrintPageEventArgs e)
    {    
        // Here you can play with the font style (and much much more, this is just an ultra-basic example)
        Font fnt = new Font("Courier New", 12);
    
        // Insert the desired text into the PDF file
        e.Graphics.DrawString("When nothing goes right, go left", fnt, System.Drawing.Brushes.Black, 0, 0);
    }
