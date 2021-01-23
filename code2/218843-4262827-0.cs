    void AFunction<T>(T aType)
    {
        if ((aType as Type).Name == "String")
        {
            Console.WriteLine("We have a string");
        }
        else
        {
            Console.WriteLine("We have something else");
        }
    }
