    Person myPerson = new Person { FirstName = "Hanne", LastName = "Schokkele", Age = 7 };
    Func<Person, Int32> myDel = myPerson.GetAge;
    double averageAge = people.Average(p => p.Age);
    double averageAge2 = people.Average(delegate(Person p) { return p.Age; });
    double averageAge3 = people.Average(myDel);
