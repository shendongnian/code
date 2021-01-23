    class Log {
      private readonly List<Status> statuses;
      public Log(List<Status> items)
      {
         statuses = items;
      }
      public Status this[int i]
      {
          get { return statuses[i]; }
      }
    }
    public SomeClass
    {
       public Log log { get; private set; }
    }
