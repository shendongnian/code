    public class Node {
        public Node Left {get; set:}
        public Node Right {get; set;}
        public Node Parent {get; set;}  // if you want to be able to go up the tree
        public Node Root {get; set;}    // only if you want a direct link to root
    }
