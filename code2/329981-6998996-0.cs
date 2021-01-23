    public class A
    {
        protected void BasePrintMe() { Console.WriteLine("A"); }
        public virtual void PrintMe() { BasePrintMe(); }
    }
    public class B : A { public override void PrintMe() { Console.WriteLine("B"); } }
    public class C : B
    {
        public override void PrintMe() { Console.WriteLine("C"); }
        public void FunA()
        {
            // call C::PrintMe - part one
            PrintMe();
            // call B::PrintMe - part two
            base.PrintMe();
            // call A
            this.BasePrintMe();
            
        }
    }
