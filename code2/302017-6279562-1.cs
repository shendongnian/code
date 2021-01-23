    System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.txt");
    
    String line;
    String[] array;
    
    while((line = file.ReadLine()) != null)
    {
       if (line.Contains("myString"))
       {
          array = line.Split(',');
       }
    }
    
    file.Close();
