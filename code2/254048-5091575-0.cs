    public class Person
    {
        public string Name { get; set; }
    }
    Person person = new Person { Name = "Vaysage" };
    Person[] persons1 = new Person[] { person  };
    Person[] persons2 = (Person[])persons1.Clone();
    persons2[0].Name = ".NET Junkie";
    Assert.AreEqual(persons1[0].Name, ".NET Junkie");
