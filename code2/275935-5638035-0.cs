    class A
    {
       protected int Test;
    }
    class B:A
    {
       public B()
       {
           int someInt = this.Test;
       }
    }
