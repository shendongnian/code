    Person p = new p();
    IBiographicalData iBio = (IBiographicalData)p;
    ICustomReportData iCr = (ICustomReportData)p;
    
    Console.WriteLine(p.LastName);
    Console.WriteLine(iBio.LastName);
    Console.WriteLine(iCr.LastName);
