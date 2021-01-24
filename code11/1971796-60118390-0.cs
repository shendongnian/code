    public class MyParentClass
    {
        public virtual void SomeMethod()
        {
        /* do parent class stuff here */
        }
    }
    public class MyChildClass : MyParentClass
    {
       public override void SomeMethod()
       {
        /* do child class stuff here */
        base.SomeMethod(); // <--- This will call the parent class method
       }
    }
