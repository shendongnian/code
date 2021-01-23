    class Animal //should this class really be abstract?
    {
        public virtual void Talk()
        {
            Console.WriteLine("-");
        }
    
        public virtual Animal Duplicate()
        {
            return new Animal(); 
        }
    }
    class Dog : Animal
    {
        public override void Talk()
        {
            Console.WriteLine("Woof");
        }
    
        public override Animal Duplicate()
        {
            return new Dog();
        }
    }
    class Cat : Animal
    {
        public override void Talk()
        {
            Console.WriteLine("Miau");
        }
    
        public override Animal Duplicate()
        {
            return new Cat();
        }
    }
