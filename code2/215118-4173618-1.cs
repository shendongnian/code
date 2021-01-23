    public class Base{
        public virtual void Method(){
            MethodImpl();
        }
        public void MethodImpl(){
            Console.WriteLine("Base");
        }
    }
    public class Child : Base{
        public override void Method(){
            Console.WriteLine("Child");
        }
    }
