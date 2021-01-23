    interface IWeapon
    {
      void Hit(string target);
    }
    
    class Sword : IWeapon
    {
      public void Hit(string target)
      {
        Console.WriteLine("Chopped {0} clean in half", target);
      }
    }
    
    class BowAndArrow : IWeapon
    {
      public void Hit(string target)
      {
        Console.WriteLine("Shot {0} right in the chest!", target);
      }
    }
    
    class Shuriken : IWeapon
    {
      public void Hit(string target)
      {
        Console.WriteLine("Pierced {0}'s armor", target);
      }
    }
