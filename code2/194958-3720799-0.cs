    class Animal<T>
    {
        public virtual void Play(List<T> animal) { }
    }
    class Cat : Animal<Cat>
    {
        public override void Play(List<Cat> cat)
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat();
            cat.Play(new List<Cat>());
        }
    }
