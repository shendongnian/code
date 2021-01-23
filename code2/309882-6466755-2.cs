    List<string> found = new List<string>();
    string line;
    using(StreamReader file =  new StreamReader("c:\\test.txt"))
    {
       while((line = file.ReadLine()) != null)
       {
          if(line.Contains("eng"))
          {
             found.Add(line);
          }
       }
    }
