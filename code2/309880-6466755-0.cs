    List<string> found = new List<string>();
    using(System.IO.StreamReader file = 
       new System.IO.StreamReader("c:\\test.txt");
    while((line = file.ReadLine()) != null)
    {
       if(line.Contains("eng"))
       {
           found.Add(line);
       }
    }
    )
