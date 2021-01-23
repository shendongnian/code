    interface A
    {
        void a();
    }
    
    interface B : A
    {
        new void a();
    }
    
    class C : B
    {
        void A.a() { Console.WriteLine("Called by interface A!"); }
        void B.a() { Console.WriteLine("Called by interface B!"); }
    }
    
    static class Test
    {
        public static void DoTest()
        {
            B b = new C();
            b.a();       // Produces "Called by interface B!"
            ((A)b).a();  // Produces "Called by interface A!"
        }
    }
