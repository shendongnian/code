    using System;
    class MyClass
    {
        public virtual void A()
        {
            Console.WriteLine("MyClass.A");
        }
        public virtual void B()
        {
            Console.WriteLine("MyClass.B");
        }
    }
    
    class ClassA : MyClass
    {
        public override void A()
        {
            Console.WriteLine("AttachmentA.A");
            
            base.A();
        }
    }
    
    class ClassB : MyClass
    {
        public override void B()
        {
            Console.WriteLine("AttachmentB.B");
        }
    }
    
    public class Program
    {
        public static void Main(string[] Args)
        {
            MyClass aaa = new ClassA();
            MyClass bbb = new ClassB();
    
            aaa.A(); // prints MyClass.A
            aaa.B(); // prints MyClass.B
            (aaa as ClassA).A(); // prints AttachmentA.A
            (aaa as ClassA).B(); // prints MyClass.B
            bbb.A(); // prints MyClass.A
            bbb.B(); // prints MyClass.B
            (bbb as ClassB).A(); // prints AttachmentB.A + MyClass.A
            (bbb as ClassB).B(); // prints AttachmentB.B
        }
    }
