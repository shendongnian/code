    for (int i = 0; i < vel; ++i)
    {
      player.Y += 1;
      if (player.CheckCollisions())
      {
        // handle collision
        break;
      }
    }
