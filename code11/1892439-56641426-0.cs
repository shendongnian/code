    private int ComputeDelta(int src, int dst, int mapSize)
    {
        int increasing, decreasing;
        if (dst >= src)
        {
            increasing = dst - src;               // increasing direction is direct
            decreasing = (mapSize + src) - dst;   // decreasing direction is toroidal
        }
        else
        {
            increasing = (mapSize + dst) - src;   // increasing direction is toroidal
            decreasing = src - dst;               // decreasing direction is direct
        }
    
        if (increasing <= decreasing) { return  increasing; }
        else                          { return -decreasing; }
    }
    
    public Position GetNextStepTowards(Position origin, Position target)
    {
        Position nextStep = new Position(0, 0);
    
        // compute the distances
        int dx = ComputeDelta(origin.X, target.X, mapXSize);
        int dy = ComputeDelta(origin.Y, target.Y, mapYSize);
    
        // keep the dominant distance, and clear the other distance
        // keep both if they're equal
        if      (dx*dx > dy*dy) { dy = 0; }
        else if (dx*dx < dy*dy) { dx = 0; }
    
        // normalize the distances so they are -1, 0, or 1
        nextStep.X = dx.CompareTo(0);
        nextStep.Y = dy.CompareTo(0);
    
        return nextStep;
    }
