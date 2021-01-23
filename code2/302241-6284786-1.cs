    public class Person
    {
        public string Name {get;set;}
    }
    List<List<Person>> superHeroes = new List<List<Person>>();
    List<Person> persons = new List<Person>();
    Person p = new Person {Name = "Superman"};
    Person p2 = new Person {Name = "Batman"};
    Person p3 = new Person {Name = "Spiderman"};
    persons.Add(p);
    persons.Add(p2);
    persons.Add(p3);
    superHeroes.Add(persons);
    string batmanName = superHeroes[0][0].Name; //returns "Superman"
