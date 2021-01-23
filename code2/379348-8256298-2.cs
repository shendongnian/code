    public static class ExampleProcessorFactory
    {
       public static ExampleProcessor Create()
       {
           if(IsFullmoon)
               return new ExampleProcessorA();
           else
               return new ExampleProcessorB();
       }
    }
