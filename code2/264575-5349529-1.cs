    Person p1 = new Person { ID = 1, FirstName = "John", LastName = "Doe", Age = 50 };
    Person p2 = new Person { ID = 2, FirstName = "John", LastName = "Doe", Age = 50 };
    Person p3 = new Person { ID = 3, FirstName = "Jane", LastName = "Roe", Age = 50 };
    Person p4 = new Person { ID = 4, FirstName = "John", LastName = "Doe", Age = 60 };
    bool areSame = CompareExcept(p1, p2, "ID"); // True
    areSame = CompareExcept(p1, p2, "Age"); // False
    areSame = CompareExcept(p1, p3, "ID"); // False
    areSame = CompareExcept(p1, p3, "ID", "FirstName", "LastName"); // True
    areSame = CompareExcept(p1, p4, "ID"); // False
    areSame = CompareExcept(p1, p4, "ID", "Age"); // True
