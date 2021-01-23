    class Node {
      public Node() { Children = new Node[0]; }
      public String Name { get; set; }
      public IEnumerable<Node> Children { get; set; }
    }
