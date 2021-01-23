    IEnumerable<int> input;
    int threshold;
    List<List<int>> clusters = new List<List<int>>();
    foreach(var current in input)
    {
        // Search the current list of clusters for ones which contain at least one
        // entry such that the difference between it and x is less than the threshold
        var matchingClusters = 
            clusters.Where(
                cluster => cluster.Any(
                               val => Math.Abs(current - val) <= threshold)
            ).ToList();
        
        // Merge all the clusters that were found, plus x, into a new cluster.
        // Replace all the existing clusters with this new one.
        IEnumerable<int> newCluster = new List<int>(new[] { current });
        foreach (var match in matchingClusters)
        {
            clusters.Remove(match);
            newCluster = newCluster.Concat(match);
        }
        clusters.Add(newCluster.ToList());
    }
