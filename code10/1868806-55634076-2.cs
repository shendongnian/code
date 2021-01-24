public class Person
{
     public string Name { get; set;}
     public string Height { get; set; }
     public string WhatEverElse { get; set; }
     public List<Pet> Pets { get; set; }
     public string Person(string Name, string Height, string WhatEverElse)
     {
          Pets = new List<Pet>();
     }
}
public class Pet
{
     public string Name { get; set; }
}
You can then add any amount of Pets by assigning new Pets
// For your own sake keep a clear naming convention - just my two bucks
List<Person> persons = new List<Person>();
Person person = new Person("Larry", "5'9", "Whatever");
persons.Add(person);
foreach(Datarow row in OwnedPets)
{
     Pet newPet = new Pet();
     person.Add(newPet);
}
