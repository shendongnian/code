    System.IO.StreamReader file;
    using(file = new StreamReader(@"c:\myfile.txt"))
    {
        while((line = file.ReadLine()) != null)
        {
         // do something with the line
        }
    }
     
