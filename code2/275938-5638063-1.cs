    class A
    {
       protected int Test;
    }
    class B : A
    {
       public B()
       {
         this.Test = 42; // Possible
       }
    }
