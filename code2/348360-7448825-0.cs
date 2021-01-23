    class A
    {
       private static readonly A _instance = new A();
       public virtual A instance 
       { 
            get
            {
                 return _instance;
            }
       }
       private A()
       {
       }
    }
