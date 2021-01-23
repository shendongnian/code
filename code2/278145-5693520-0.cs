    interface ITest
    {
      void TestVoid();
    }
    class A : ITest
    {
       public static void Main()
       {
           A a1 = new A();
           ITest a2 = new A();
           a1.TestVoid(); // won't work
           a2.TestVoid(); // will work
       }
       public void ITest.TestVoid()
       {
         Conole.WriteLine("Done");
       }
    }
