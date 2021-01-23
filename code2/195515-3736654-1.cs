    delegate Mammal F();
    static Animal GetAnimal() {...}
    static Mammal GetMammal() {...}
    static Tiger GetTiger() {...}
    F fm = GetMammal; 
    Mammal m = fm();
   
