    class Node {
        public object Value;
        // Connected nodes (directed)
        public Node[] Connections;
        // Path back to the start
        public Node Route;
    }
    Node BreadthFirstRoute(Node[] theStarts, Node[] theEnds) {
        Set<Node> visited = new Set<Node>();
        Set<Node> frontier = new Set<Node>();
        frontier.AddRange(theStarts);
        Set<Node> ends = new Set<Node>();
        ends.AddRange(theEnds);
        // Visit nodes one frontier at a time - Breadth first.
        while (frontier.Count > 0) {
            // Move frontier into visiting, reset frontier.
            Set<Node> visiting = frontier;
            frontier = new Set<Node>();
            // Prevent adding nodes being visited to frontier
            visited.AddRange(visiting);
            // Add all connected nodes to frontier.
            foreach (Node node in visiting) {               
                foreach (Node other in node.Connections) {
                    if (!visited.Contains(other)) {
                        other.Route = other;
                        if (ends.Contains(other)) {
                            return other;
                        }
                        frontier.Add(other);
                    }
                }
            }
        }
        return null;
    }
