    static public void TestQop()
    {
      someMethod(new Qop1(), 0, 0, 0);
      someMethod(new Qop2(), 1, 1, 1);
    }
    static void someMethod<T>(T qop, int simulator, int param1, int param2) 
      where T : QopBase
    {
      qop.Run(simulator, param1, param2);
    }
    abstract class QopBase
    {
      public abstract void Run(int simulator, int param1, int param2);
    }
    class Qop1 : QopBase
    {
      public override void Run(int simulator, int param1, int param2)
      {
        QuantumOperation1.Run(simulator, param1, param2);
      }
    }
    class Qop2 : QopBase
    {
      public override void Run(int simulator, int param1, int param2)
      {
        QuantumOperation2.Run(simulator, param1, param2);
      }
    }
