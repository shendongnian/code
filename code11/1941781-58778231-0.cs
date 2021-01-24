    private List<Bubble> FindAllRecursiveNeighbors(Vector2Int originPosition, List<Bubble> result = null)
    {
        List<Bubble> allNeighbors = FindNeighbors(originPosition);
    
        if (result == null)
            // Mark (see bellow)
            result = new List<Bubble>();
    
        var newBubbles = new List<Bubble>();
        foreach (Bubble bubble in allNeighbors)
        {
            if (!result.Contains(bubble))
            {
                result.Add(bubble);
                newBubbles.Add(bubble);
            }
        }
    
        // Recursion starts here.
        foreach (Bubble bubble in newBubbles)
        {
            List<Bubble> neighbors = FindAllRecursiveNeighbors(FindPositionOfBubble(bubble), result);
        }
    
        return result;
    }
