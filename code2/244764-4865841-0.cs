    var closed = new HashSet<Node>();
    var queue = new PriorityQueue<double, Path<Node>>();
    queue.Enqueue(0, new Path<Node>(start));
    while (!queue.IsEmpty)
    {
        var path = queue.Dequeue();
        if (closed.Contains(path.LastStep)) continue;
        if (path.LastStep.Equals(destination)) return path;
        closed.Add(path.LastStep);
        foreach(Node n in path.LastStep.Neighbours)
        {
            double d = distance(path.LastStep, n);
            var newPath = path.AddStep(n, d);
            queue.Enqueue(newPath.TotalCost + estimate(n), newPath);
        }
    }
