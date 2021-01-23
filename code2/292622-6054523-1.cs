    List<Int32> values = new List<Int32>();
    bool open = false;
    String[] lines = File.ReadAllLines(fileName);
    foreach(String line in lines)
    {
      if( (!open) && (line == "-") )
      {
        open = true;
      }
      else if( (open) && (line == "~") )
      {
        open = false;
      }
      else if(open)
      {
        Int32 v;
        if(Int32.TryParse(line, out v)) 
        {
          values.Add(v);
        }
      }
    }
    Listbox.Items.AddRange(values);
