    bool keepLooping = true;
    while (keepLooping)
    {
      keepLooping = false;
      for (int x = 0; x < maxx; x++)
      {
        for (int y = 0; y < maxy; y++)
        {
          if (DoSomething(x, y))
          {
            keepLooping = true;
            break;
          }
        }
        if (keepLooping)
        {
          break;
        }
      }
    }
