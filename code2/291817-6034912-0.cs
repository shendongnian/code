    class BaseClass
    {
      protected int Level { get; set; }
    }
    
    class SubClass : BaseClass
    {
      public int Points { get { return Level; } set { Level = value; } }
    }
