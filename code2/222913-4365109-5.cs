    class Program
    {
      public static void Main()
      {
        Samurai warrior1 = new Samurai(new Sword());
        Samurai warrior2 = new Samurai(new Shuriken());
        Samurai warrior3 = new Samurai(new BowAndArrow());
    
        warrior1.Attack("the evildoers");
        warrior2.Attack("the big guy in front");
        warrior3.Attack("the scared guy running away");
      }
    }
