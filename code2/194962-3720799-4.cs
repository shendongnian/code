    class Animal<T>
    {
        public virtual void Play(List<T> animals) { }
    }
    class Cat : Animal<Cat>
    {
        public override void Play(List<Cat> cats)
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
