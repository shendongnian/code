    public class A
    {
        public virtual int Num
        {
            get { return 1; }
        }
    
        public int GetClassNum<T>(T instance) where T : A
        {
            return instance.Num;
        }
    }
    
    public class B : A
    {
        public override int Num
        {
            get { return 2; }
        }
    }
    
    public class C : A
    {
        public override int Num
        {
            get { return 3; }
        }
    }
