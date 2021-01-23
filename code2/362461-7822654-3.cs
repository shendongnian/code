    List<string> lines = new List<string>();
    string buffer = "";
    int count = 1;
    
    foreach(char c in input)
    {
       if(c.ToString() == count.ToString())
       {
          if(!string.IsNullOrEmpty(buffer))
          {
             lines.Add(buffer);
             buffer = "";
          }
          count++;
       }
       buffer += c;
    }
    
    //lines will now contain your splitted data
