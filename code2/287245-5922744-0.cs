    public class B : A<B>
    {
        public B()
        {
            myVariable = 1;
        }
        public int GetVariable()
        {
            return myVariable;
        }
    }
    
    public class C : A<C>
    {
        public C()
        {
            myVariable = 2;
        }
        public int GetVariable()
        {
            return myVariable;
        }
    }
