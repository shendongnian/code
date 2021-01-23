    Person p = new Person();
    p.Age = this.Age;  // value copy
    p.Name = this.Name; // value copy
    p.IdInfo = this.IdInfo; // reference copy. this object is the same in both coppies.
    return p;
