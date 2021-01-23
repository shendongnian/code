    class Base
    {
        public enum myEnum
        {
            hello, to, you
        }
        public void doIt(myEnum e)
        {
            Console.Out.WriteLine(e);
        }
        static void Main(string[] args)
        {
            Base a = new Child();
            a.doIt(Child.myEnum.hello); // this is a syntax error because doIt requires a Base.myEnum, not a Child.myEnum.
        }
    }
    class Child : Base
    {
        public new enum myEnum
        {
                hello, my, dear
        }
    }
