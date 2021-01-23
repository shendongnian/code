    public static void DoSomething(Animal animal)
    {
        if (animal is Dog)
        {
          MyKennelMethod((animal as Dog).Kennel);
        }
        else if (animal is Bird)
        {
          MyNestMethod((animal as Bird).Nest);
        }
    }
