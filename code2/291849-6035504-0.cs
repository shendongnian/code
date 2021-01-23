    int x = 0;
    int startTime = Environment.TickCount;
    for (int i = 0; i < 1000000; i++)
    {
        x++;
        int currentTime = Environment.TickCount;
        if ((currentTime - startTime) > 1000)
        {
            break;
        }
    }
