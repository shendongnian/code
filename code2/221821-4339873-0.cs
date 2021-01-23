    var fileContents = System.IO.File.ReadAllText(@"C:\File.html");
    
    fileContents = fileContents.Replace("<body>", "<body onload='jsFx();' />"); 
    fileContents = fileContents.Replace("</body>","blah blah blah </body>"); 
    
    System.IO.File.WriteAllText(fileContents, @"C:\File.html");
