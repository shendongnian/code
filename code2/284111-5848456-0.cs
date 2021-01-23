    class Data
    {
      string Name {get;set;}
      int Age {get;set;}
    }
    List<Data> array = new List<Data>();
    string line;
    using (StreamReader sr = new StreamReader(path))
    {
      sr.ReadLine();
      while ((line == sr.ReadLine()) != null)
      {
        string[] channels = line.Split('|');    
        array.Add(new Data() {Age=int.Parse(channels[0]), Name=channels[1]);       
      }
    }
