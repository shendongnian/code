    var clusters = Enumerable
            .Range(1, 10)
            .Select(_ => new RecurringClusterModel
            {
                REC_Cluster_1 = _Locations[_Random.Next(_Locations.Count)],
                REC_Cluster_2 = _Locations[_Random.Next(_Locations.Count)],
                REC_Cluster_3 = _Locations[_Random.Next(_Locations.Count)],
            })
            .ToList();
    var dictionary = clusters
        // Flatten the list and preserve original object
        .SelectMany(model => model.Clusters.Select(cluster => (cluster, model)))
        // Group by flattened value and put original object into each group
        .GroupBy(node => node.cluster, node => node.model)
        // Depending on further processing you could put the groups into a dictionary.
        .ToDictionary(group => group.Key, group => group.ToList());
    foreach (var cluster in dictionary)
    {
        Console.WriteLine(cluster.Key);
        foreach (var item in cluster.Value)
        {
            Console.WriteLine("   " + String.Join(", ", item.Clusters));
        }
    }
