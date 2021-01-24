using System;
using System.Collections.Generic;
I made a few changes to your ```Person``` class 
public class Person
{
    public Person(string name)
    {
        Siblings = new List<Person>();
        Name = name;
    }
    public int ID { get; set; }
    public string Name { get; set; }
    public List<Person> Siblings { get; set; }
}
Then, using the ```ForEach()``` method I was able to print the list of siblings for each person in the list.
var people = new List<Person>()
{
    new Person("Amanda"),
    new Person("Lucas"),
    new Person("George"),
};
var siblings = new List<Person>()
{
    new Person("Mari"),
    new Person("Vini"),
    new Person("Diego"),
};
foreach (var sibling in siblings)
{
    people.ForEach(p => p.Siblings.Add(sibling));
}
foreach (var person in people)
{
    person.Siblings.ForEach(s => Console.WriteLine($"{person.Name} has {s.Name} as sibling"));
}
The output was:  
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/PFUeC.png
Hope it helps.
