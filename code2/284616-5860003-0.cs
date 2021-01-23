    // See if the key is currently down
    if (KeyIsDown(key))
    {
      if (gameTime.ElapsedSeconds >= nextTime)
      {
        // Move the character, and indicate that you want to wait another second for movement.
        moveTheCharacter();
        nextTime = gameTime.ElapsedSeconds + 1;
      }
    }
