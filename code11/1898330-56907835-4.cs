    //This is how it looks when TeamA provides a new release with a new method
    public class BaseClass
    {
        public Method1();
        public Method2();
        public NewMethod();
    }
    public class CustomBaseClass : BaseCLass
    {
        public override Method1(); //customized now, and will affect all existing classes automatically
    }
    public class A : CustomBaseClass
    {
        public override Method1();
        public override Method2();
    }
    public class B : CustomBaseClass
    {
        public override Method1();
        public override Method2();
    }
    public class C : CustomBaseClass
    {
         public override Method1();
         public override Method2();
    }
