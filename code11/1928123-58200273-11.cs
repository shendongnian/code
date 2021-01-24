    public class Person {
      public string FirstName { get; set; }
      public string LastName { get; set; }
    }
    public class City {
      public string Name { get; set; }
    }
    ...
 
    var person = new Person() {
      FirstName = "John",
      LastName = "Smith",
    },
    var city = new City() {
      Name = "New York"
    };
    ...
    string stringToModify = 
      "Hello my name is {person.firstname} and my house is in {city.name}"; 
    string result = ReplaceMyMask(stringToModify, person, city);
    Console.Write(result);
