    Excel.Application app = new Excel.ApplicationClass();
    			
    Excel.Workbook book =  app.Workbooks.Open(Filename: System.IO.Path.Combine( Environment.CurrentDirectory, "Book1.xls"));
    			
    Excel.Name MyRange = 	book.Names.Item(Index:"MyRange");
    			
    Console.WriteLine(MyRange.RefersToRange.Value);
    			
    MyRange.RefersToRange.Value  = "55";
    			
    book.Save();
    
    app.Quit();
