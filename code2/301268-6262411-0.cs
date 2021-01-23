    class B
    {
      public IA Implementer {get; private set;}
      public B(IA a) 
      {
          Implementer = a;
      }
    }
