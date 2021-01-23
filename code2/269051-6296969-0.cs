    public void depthFirstSearch(Graph graph, Vertex start){
        Set<Vertex> visited = new HashSet<Vertex>(); // could use vertex.isVisited()...
        Deque<Vertex> stack = new ArrayDeque<Vertex>(); // stack implies depth first
        
        // first visit the root element, then add it to the stack so
        // we will visit it's children in a depth first order
        visit(start);
        visited.add(start);
        stack.push(start);   
        
        while(stack.isEmpty() == false){
            List<Edge> edges = graph.getEdges(stack.peekFirst());
            Vertex nextUnvisited = null;
            for(Edge edge : edges){
                if(visited.contains(edge.getEndVertex)) == false){
                   nextUnvisited = edge.getEndVertex();
                   break; // break for loop
                }
            }
            if(nextUnvisited == null){
                // check the next item in the stack
                Vertex popped = stack.pop();
            } else {
                // visit adjacent unvisited vertex
                visit(nextUnvisited);
                visited.add(nextUnvisited);
                stack.push(nextUnvisited); // visit it's "children"
            }
        }
    }
    public void visit(Vertex vertex){
        // your own visit logic (string append, etc)
    }
