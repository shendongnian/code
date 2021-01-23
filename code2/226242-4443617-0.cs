    interface IAnimal
    {
        void Speak();
    }
    class Cat : IAnimal
    {
        void Speak()
        {
            MessageBox.Show("Meow!");
        }
    }
    class Dog : IAnimal
    {
        void Speak()
        {
            MessageBox.Show("Woof!");
        }
    }
    static class Program
    {
        private void SpeakPlease(IAnimal animal)
        {
            animal.Speak();
        }
     //...
     }
