    public class Node {
      [ScriptIgnore]
      public Node Parent { get; set; }    
      public ICollection<Node> Children { get; set; }
    }
