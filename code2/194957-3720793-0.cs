    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat();
            cat.Play(new List<Cat>().Cast<Animal>());
        }
    }
