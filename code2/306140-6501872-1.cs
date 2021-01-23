    var clusters = SharpLearning.Clustering.KCluster(k, iterations, listOfIClusterableObjects);
    foreach (var cluster in clusters) {
        // Process some data.
        // clusters is a List<Cluster<T>> where your objects can be viewed in the .Members attribute
    }
