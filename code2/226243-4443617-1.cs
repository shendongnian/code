    interface IAnimal
    {
        void Speak();
    }
    class Cat : IAnimal
    {
        public void Speak()
        {
            MessageBox.Show("Meow!");
        }
    }
    class Dog : IAnimal
    {
        public void Speak()
        {
            MessageBox.Show("Woof!");
        }
    }
    static class Program
    {
        static void SpeakPlease(IAnimal animal)
        {
            animal.Speak();
        }
     //...
     }
