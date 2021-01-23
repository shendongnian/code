    abstract class Node { }
    class DataNode : Node {
        public string Data { get; }
      
        // details
    }
    class OperatorNode : Node {
        public Node Left { get; }
        public Node Right { get; }
        public BinaryOperator Operator { get; }
        // details
    }
  
    abstract class BinaryOperator { // details }
    class Or : BinaryOperator { // details }
    class And : BinaryOperator { // details }
