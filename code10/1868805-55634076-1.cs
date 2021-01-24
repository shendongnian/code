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
Pet newPet = new Pet();
//add a pett to the secund element in the list
person[i].Pets.Add(newPet);
