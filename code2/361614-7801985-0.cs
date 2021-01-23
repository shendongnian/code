    static void Main(string[] args)
    {
        MyClass mc = new MyClass();
        mc.doStuff();
    }
    interface IMember
    {
        void doStuff();
    }
    class Member1 : IMember
    {
        public void doStuff()
        {
            Console.WriteLine("Member1");
        }
    }
    class Member2 : IMember
    {
        public void doStuff()
        {
            Console.WriteLine("Member2");
        }
    }
    class Member3 : IMember
    {
        public void doStuff()
        {
            Console.WriteLine("Member3");
        }
    }
    class Member4 : IMember
    {
        public void doStuff()
        {
            Console.WriteLine("Member4");
        }
    }
    class MyClass
    {
        public Member1 member1 = new Member1();
        public Member2 member2 = new Member2();
        public Member3 member3 = new Member3();
        public Member4 member4 = new Member4();
        public void doStuff()
        {
            IMember[] members = { member1, member2, member3, member4 };
            foreach (IMember member in members)
                member.doStuff();
        }
    }
