        Plant p = new Plant();
        p.SetEngines();
        foreach (Car c in p.Cars)
        {
            Console.WriteLine("{0} - {1} cv",c.Model, c.Engine.Power);
        }
        Console.ReadLine();
