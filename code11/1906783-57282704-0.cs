    public abstract class  A
    {
        public  int Prop1 { get; set; }
        public B GetB()
        {
            return new B(){Prop1 = 10, Prop2 = 20};
        }
    }
    public class B : A
    {
        public int Prop2 { get; set; }
    }
