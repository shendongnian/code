    double _weightSum;
    ...
    // initialize the Sum somewhere
    _weightSum = moves.SumBy(m => m.Weight);
    
    Move GetRandomMove()
    {
        var value = rnd.NextDouble()*weightSum;
        foreach(var move in moves.OrderByDescending(m => m.Weight))
        {
           value -= move.Weight;
           if (value <= 0) return move;
        }
    }
