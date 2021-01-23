    public IEnumerable<Plant> GetTreesNodes(IEnumerable<Plant> roots)
    {
        if(!roots.Any())
        {
            return Enumerable.Empty<Plant>();
        }
    
        var rootsIds = roots.Select(root => root.ID);
        var children = plants.Where(plant => rootsIds.Contains(plant.Parent));
        return roots.Union(GetTreesNodes(children));
    }
