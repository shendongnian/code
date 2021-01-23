    public static void DoSomething(Animal animal)
    {
        if (animal is Dog)
        {
          Dog dog = animal as Dog;
          MyKennelMethod(dog.Kennel);
        }
        else if (animal is Bird)
        {
          Bird bird = animal as Bird;
          MyNestMethod(bird.Nest);
        }
    }
