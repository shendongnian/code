    string lives = "life";
    if (player.Lives > 1)
    {
        lives = PluralizationService
            .CreateService(new CultureInfo("en-US"))
            .Pluralize(lives);
    }
    Console.WriteLine("You have {0} {1} left", lives, player.Lives);
