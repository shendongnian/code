    class Base
    {
        public void Bar() { Console.WriteLine("Base"); }
    }
    class Derived : Base
    {
        public new void Bar() { Console.WriteLine("Derived"); }
    }
