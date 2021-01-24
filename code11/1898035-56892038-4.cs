    void DisplayHealth(IMonster monster)
    {
        Console.WriteLine(monster.Health);
    }    
    var hydra = new Hydra
    {
        HeadHealth = 25,
        BodyHealth = 100
    }
    
    var snake = new Snake
    {
        Health = 50
    }
    DisplayHealth(hydra) //125
    DisplayHealth(snake) //50
