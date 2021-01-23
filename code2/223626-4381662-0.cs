    class Node {
        public Node Left { get; }
        public Node Right { get; }
        public BinaryOperator Operator { get; }
        // details elided (ctor, etc.)
    }
    abstract class BinaryOperator { // details }
    class Or : BinaryOperator { // details }
    class And : BinaryOperator { // details }
