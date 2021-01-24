    public Journey GetLatestPath()
    {
        if (cameFrom == null || cameFrom.Count == 0 || costSoFar == null || costSoFar.Count == 0)
        {
            //Trying to run this before running an A* search.
            return null;
        }
        int pathTravelTime = 0;
        List<MapHex> path = new List<MapHex>();
        MapHex current = aStarLatestGoal;
        
        while (!current.Equals(aStarLatestStart))
        {
            if (!cameFrom.ContainsKey(current))
            {
                //A* was unable to find a valid path.
                return null;
            }
            path.Add(current);
            current = cameFrom[current];
            pathTravelTime += HexHeuristicDistance(current, path[path.Count - 1]);
        }
        path.Reverse();
        return new Journey(path, aStarLatestStart, pathTravelTime);
    }
