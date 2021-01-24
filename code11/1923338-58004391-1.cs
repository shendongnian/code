    public class Person{
      public string Name { get; set; };
      public int Id { get; set; };
    }
    var peeps = new List<Person>(){
      new Person(){ Name="John",Id=1 },
      new Person(){ Name="Jane",Id=2 }
    };
    combo.DataSource = peeps;
    combo.DisplayMember = "Name";
    combo.ValueMember = "Id";
