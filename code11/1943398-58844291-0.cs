    public class Foo
    {
        public string ProA { get; set; }
        public Foo(string proa) => ProA = proa ?? 
            throw new ArgumentNullException("Invalid proa value");
    }
