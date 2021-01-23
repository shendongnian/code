    interface IAnimal
    {
        string Speak();
    }
    
    class Dog : IAnimal
    {
        public string Speak()
        {
            return "Bark!";
        }
    }
