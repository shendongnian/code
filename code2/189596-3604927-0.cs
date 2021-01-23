    class BaseFoobar
    {
       public static readonly ILog log = LogManager.GetLogger(typeof(BaseFoobar));
    }
    
    class SpecializedFoobar : BaseFoobar
    {
       public void Whatever()
       {
          log.Error("I exploded");
       }
    }
