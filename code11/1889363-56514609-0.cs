/// <summary>
/// Checks for collision with obstacles, platforms and exits.
/// </summary>
private void CollisonCheck()
{
    var platformCollision = Player.CollisionPlatform(Parser.PlatformEntities, false);
    var obstacleCollision = Player.CollisionObstacle(Parser.ObstacleEntities, false);
    var exitCollision = Player.CollisionObstacle(Parser.ExitEntities, false);
    // Landing on platform
    if (platformCollision.Item1 && obstacleCollision)
        DockAtPlatform(); // Stand still on platform
    else if (exitCollision)
        ExitMap(); // Exit map         
    else if (obstacleCollision)
        CollideWithObject(); // Collision with obstacle. Add explosion
    // ??? Player collision can occur at a platform or in general regions in the map
    if (Player.CollisionCustomer(allCustomersInMap).Item1 && !Player.HasCostumer)
        PickupCustomer();
}
/// <summary>
/// Dock Player with platform as long as they are not approaching too fast.
/// Collect reward if carrying a passenger
/// </summary>
/// <remarks>If too fast, player will explode!</remarks>
private void DockAtPlatform()
{
    if (Math.Abs(Player.Entity.Shape.AsDynamicShape().Direction.Y)
        < Constants.COLLISION_DISTANCE)
    {
        Player.Shape.Direction.Y = 0;
        Player.Shape.Direction.X = 0;
        Player.OnPlatform = true;
        // Explode because of too much speed
    }
    else
    {
        AddExplosion(Player.Shape.Position.X, Player.Shape.Position.Y,
            0.1f, 0.1f);
    }
    // Be rewarded in case player transports a customer
    if (Player.HasCostumer)
    {
        foreach (var customer in pickedUpCustomers)
        {
            if (CorrectDestination(platformCollision.Item2,
                customer.DestinationPlatform))
            {
                score.AddPoint(CurrentCustomer.RewardPoints);
                customer.CanRemove = true;
                Player.HasCostumer = false;
            }
        }
    }
}
/// <summary>
/// Switch between Maps
/// </summary>
private void ExitMap()
{
    // Switch from one map to another
    if (GameRunning.CurrentMap == "the-beach.txt")
    {
        GameRunning.CurrentMap = "short-n-sweet.txt";
        Player.SetPosition(Constants.PLAYER_ENTRYPOSITION_X,
            Constants.PLAYER_ENTRYPOSITION_Y);
        Player.Entity.Shape.AsDynamicShape().Direction.Y = Constants.STILL;
        Player.Entity.Shape.AsDynamicShape().Direction.X = Constants.STILL;
    }
    else
    {
        // Switch the reverse way around
        GameRunning.CurrentMap = "the-beach.txt";
        Player.SetPosition(Constants.PLAYER_ENTRYPOSITION_X,
            Constants.PLAYER_ENTRYPOSITION_Y);
        Player.Entity.Shape.AsDynamicShape().Direction.Y = Constants.STILL;
        Player.Entity.Shape.AsDynamicShape().Direction.X = Constants.STILL;
    }
    GameRunning.Timer.Restart();
    Parser.Load(GameRunning.CurrentMap);
    allCustomersInMap = new List<Customer>();
    foreach (var c in Parser.Customer)
    {
        allCustomersInMap.Add(new Customer(c.Key, c.Value.Item1,
            c.Value.Item2, c.Value.Item3, c.Value.Item4,
            c.Value.Item5));
    }
}
/// <summary>
/// Show explosion because player has collided with an object, then return to the main menu
/// </summary>
private void CollideWithObject()
{
    AddExplosion(Player.Shape.Position.X, Player.Shape.Position.Y,
        Constants.EXPLOSION_WIDTH, Constants.EXPLOSION_HEIGHT);
    TaxiBus.GetBus()
        .RegisterEvent(GameEventFactory<object>.CreateGameEventForAllProcessors(
            GameEventType.GameStateEvent, this, "CHANGE_STATE",
            "MAIN_MENU", ""));
}
/// <summary>
/// Pickup a new customer, start the meter running and remove the customer from the map
/// </summary>
private void PickupCustomer()
{
    var customer = Player.CollisionCustomer(allCustomersInMap).Item2;
    TaxiMeterTimer = new Stopwatch();
    TaxiMeterTimer.Start();
    CurrentCustomer = customer;
    pickedUpCustomers.Add(customer);
    allCustomersInMap.Remove(customer);
    CurrentCustomer.SetPosition(Constants.HIDEPOS_X, Constants.HIDEPOS_Y);
    Player.HasCostumer = true;
}
Now you can focus on the individual actions and review them to see if there are cleaner ways to code their process.
A few notes to consider:
---
- Add Explosion should accept a point object instead of passing through the X,Y coordinates, it makes the code easier to read and is a natural way to pass coordinates that always go together.
- Instead of using Tuples, you should create specific data model classes to use as return values from the collision functions, it feels like over-engineering, but it helps both with documentation of your code and to understand the intent. 
 -  Takes little time to define a class to hold the collision response, with minimal documentation, instead of burying inside comments what `.Item1` and `.Item2` might be in terms of data type and logical meaning
 -  Yes Tuples are awesome, in terms of rapidly smashing code solutions out, but you always have to review the code that creates the values to understand or identify the meaning behind the values, so these are usually the first to be refactored out of my prototyping code when I want to get serious about a solution.
- You have a style of placing the comments for the next `if` block inside the previous branch code, move the comments to inside the affected if branch, or immediately above it
 -  Or move the branch into its own method and you can use Doc comments.
- If the Player object itself holds the meter variables, you could accept multiple passengers (up to the capacity of the vehicle) and collect multiple fares on delivery, your action for dropping off a customer at a platform already assumes multiple passengers. 
 -  You may have already catered for this in different ways
  
  [1]: https://codereview.stackexchange.com/
