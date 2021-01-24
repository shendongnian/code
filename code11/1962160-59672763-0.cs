    public class Person
    {
      public string Name {get;set;}
      public int Mark {get;set;}
    }
    
    public IEnumerable<Person> ParseFile(string filePath)
    {
      System.IO.StreamReader file = new System.IO.StreamReader(filePath);
      while((var name = file.ReadLine()) != null)
      {
        var p = new Person();
        p.Name = name;
        p.Mark = int.TryParse(file.ReadLine());
        yield return p;
      }
      file.Close();
    }
