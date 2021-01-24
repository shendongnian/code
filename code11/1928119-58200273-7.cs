    public class Person {
      public string FirstName { get; set; }
      public string LastName { get; set; }
    }
    public class City {
      public string Name { get; set; }
    }
    ...
    string source = "Hello my name is {person.firstname} and my house is in {city.name}";
    object[] context = new object[] {
      new Person() {
        FirstName = "John",
        LastName = "Smith",
      },
      new City() {
        Name = "New York"
      }
    }; 
    string result = ProcessString(context, source);
    Console.Write(result);
