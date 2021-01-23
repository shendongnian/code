    class VTable
    {
        public VTable(Func<Animal, string> eat)
        {
            this.AnimalEat = eat;
        }
        public readonly Func<Animal, string> AnimalEat;
    }
    class Animal
    {
        private static AnimalVTable = new VTable(Animal.AnimalEat);
        private static string AnimalEat(Animal _this)
        { 
            return "undefined"; 
        }
        public VTable VTable;
        public static Animal CreateAnimal() 
        { 
            return new Animal() 
                { VTable = AnimalVTable }; 
        }
    }
    class Human : Animal
    {
        private static HumanVTable = new VTable(Human.HumanEat); 
        private static string HumanEat(Animal _this)
        {
            return "human"; 
        }
        public static Human CreateHuman()
        {
            return new Human() 
                { VTable = HumanVTable };
        }
    }
    class Dog : Animal
    {
        public static string DogEat(Dog _this) { return "dog"; }
        public static Dog CreateDog()
        {
            return new Dog() 
                { VTable = AnimalVTable } ;
        }
    }
