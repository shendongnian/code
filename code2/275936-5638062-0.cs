    class A
    {
        protected int Test;
    }
    class B : A
    {
        public B()
        {
           Test = 3; //possible
           base.Test = 3;  //explicitly calling base member, but not necessary in this case
        }
    }
