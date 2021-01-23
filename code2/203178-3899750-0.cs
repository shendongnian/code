    class Animal
    {
       public abstract string Run();
    }
    
    class Dog : Animal
    {
       public override string Run()
       {
          return "Running into a wall.";
       }
    
    }
    
    class Cat : Animal
    {
       public override string Run()
       {
         return "Running up a tree";
       }
    
    }
