    System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.txt");
    
    String line;
    
    while((line = file.ReadLine()) != null)
    {
       if (line.Contains("myString"))
       {
          // do something
       }
    }
    
    file.Close();
