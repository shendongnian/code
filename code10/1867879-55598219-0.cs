public static class PlayerFactory
{
   private static BasePlayer _instance;
   public static BasePlayer Instance 
   {
      get { return _instance; }
      protected set { _instance = value; }
   } 
}
which should accept any object descended from BasePlayer as the single instance.
