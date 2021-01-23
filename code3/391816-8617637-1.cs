    var g = new BidirectionalGraph<int, IEdge<int>>();
    
    g.AddVerticesAndEdge(new Edge<int>(1, 2));
    g.AddVerticesAndEdge(new Edge<int>(2, 3));
    g.AddVerticesAndEdge(new Edge<int>(3, 4));
    g.AddVerticesAndEdge(new Edge<int>(2, 4));
    
    var astar =new AStarShortestPathAlgorithm<int,IEdge<int>>(g, x => 1.0, x => 0.0);
    var dist = astar.ComputeDistanceBetween(2, 4);
