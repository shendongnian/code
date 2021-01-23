    class Person : IPerson
    {
     IPerson1 Person1 {get; private set;}
     IPerson2 Person2 {get; private set;}
     // DI through constructor. If the type IPerson1 or IPerson2 are not registered, it will be set to null.
     Person(IPerson1 objPerson1, IPerson2 objPerson2)
     {
       this.Person1 = objPerson1;
       this.Person2 = objPerson2;
     }
    }
