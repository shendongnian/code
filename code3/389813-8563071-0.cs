    class Dog {
        public void Woof();
    }
    
    Dog d = new Dog();
    d.Woof(); // OK
    
    object o = new Dog();
    o.Woof(); // COMPILER ERROR
