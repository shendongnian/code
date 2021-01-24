    sealed class ActionToFSharpFunc<T> : FSharpFunc<T, Unit>
    {
      readonly Action<T> m_a;
      public ActionToFSharpFunc(Action<T> a)
      {
        m_a = a;
      }
      public override Unit Invoke(T func)
      {
        m_a(func);
        return null; //IIRC The unit value is implement as null in F#
      }
    }
    static void Main(string[] args)
    {
      App.perform (new ActionToFSharpFunc<string>(Console.WriteLine));
    }
