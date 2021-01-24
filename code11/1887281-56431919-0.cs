    //Base Class
    public class Parent
    {
        public virtual void foo()
        {
            Console.WriteLine("Parent");
        }
    }
    //Child Class
    public class Child : Parent
    {
        public override void foo()
        {
            Console.WriteLine("child");
        }
    }
