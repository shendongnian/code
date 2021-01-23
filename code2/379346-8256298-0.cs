    public static class ExampleProcessorFactory
    {
       public static EampleProcessor Create()
       {
           if(IsFullmoon)
               return new ExampleProcessorA();
           else
               return new ExampleProcessorB();
       }
    }
