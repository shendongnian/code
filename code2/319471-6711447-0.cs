    if (DateTime.Now - lastTime > new TimeSpan(0, 0, 1))
       // Update the time here for your 1s clock
    lastTime = DateTime.Now;
    if (DateTime.Now - startTime > new TimeSpan(0, 0, 300))
        // Exit the game
