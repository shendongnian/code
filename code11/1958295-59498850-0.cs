    PdfDocument pdf = new PdfDocument();
    pdf.LoadFromFile("Sample.pdf");
    
    //Set the printer 
    pdf.PrintSettings.PrinterName = "HP LasterJet P1007";
    
    //Only print the second and fourth page
    pdf.PrintSettings.SelectSomePages(new int[] { 2,4 });
    
    //Print the pages from 1 to 15
    pdf.PrintSettings.SelectPageRange(1,15);
    
    pdf.Print();
