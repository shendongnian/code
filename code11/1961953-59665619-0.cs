    public abstract class A
        {
            public abstract void SomeFunction(bool flag);
        }
    
        public class B : A
        {
            public override void SomeFunction(bool flag = true)
            {
                //do something
                Console.WriteLine(flag);
            }
        }
