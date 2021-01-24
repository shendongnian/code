    class Person{
      public string Name;
      public int Id;
    }
    var peeps = new List<Person>(){
      new Person(){ Name="John",Id=1 },
      new Person(){ Name="Jane",Id=2 }
    };
    combo.DataSource = peeps;
    combo.DisplayMember = "Name";
    combo.ValueMember = "Id";
