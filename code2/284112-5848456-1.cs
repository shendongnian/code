    class Person
    {
      string Name {get;set;}
      int Age {get;set;}
    }
    List<Person> people = new List<Person>();
    string line;
    using (StreamReader sr = new StreamReader(path))
    {
      sr.ReadLine();
      while ((line == sr.ReadLine()) != null)
      {
        string[] channels = line.Split('|');    
        people.Add(new Person() {Age=int.Parse(channels[0]), Name=channels[1]});       
      }
    }
