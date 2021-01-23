    Paddle p;
    World w;
    Ball b;
    
    Rect[] paddleSections = new Rect[] 
    {
      p.Section[0],
      p.Section[1],
      p.Section[2],
      p.Section[3],
    }
    
    Rect[] worldSections = new Rect[] 
    {
      new Rect(p.Top, p.Left, p.Right, p.Bottom) // just simple world, for example
    }
    
    Rect[] ballSections = new Rect[] 
    {
      new Rect(p.Top, p.Left, p.Right, p.Bottom) // just one ball piece, for example
    }
    
    Rect[] bricksSection = new Rect[]
    {
      GetBrickRects();
    }
    
    int index = 0;
    if ((index = Collide(ballSections, worldSections) != -1)
    {
        foreach(int collideIndex in CollideIndex(ballSection[index], worldSection)
        {
            ... // somethig goes up here
        }
    }
