    //This is what TeamA provides in a release
    public class BaseClass
    {
        public Method1();
        public Method2();
    }
    public class CustomBaseClass : BaseCLass
    {
        //No code. This is just a pass-through class
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
