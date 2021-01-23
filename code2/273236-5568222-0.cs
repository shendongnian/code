    void doSomething(IAnimal animal)
    {
        if (animal is Dog)
        {
            parseDog(); // parts of a dog?
        }
        else if (animal is Cat)
        {
            parseCat();
        }
        else if (animal is Ape)
        {
            ...
        }
    }
