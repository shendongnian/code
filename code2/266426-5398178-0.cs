    class BinaryNode : Node
    {
        public Node LeftChild;
        public Node RightChild;            
        public readonly string Operator;            
    }
    class UnaryNode : Node
    {
        public Node Child;
        public readonly string Operator;
    }
    class TerminalNode : Node
    {
        public readonly string LeafItem;
    }
    class Node { }
    public class Executor
    {
        public IEnumerable<object> Get(string value)
        {
            return null;
        }
        public IEnumerable<object> GetAll()
        {
            return null;
        }
        public IEnumerable<object> GetItems(Node node)
        {
            if (node is TerminalNode)
            {
                var x = node as TerminalNode;
                return Get(x.LeafItem);
            }
            else if (node is BinaryNode)
            {
                var x = node as BinaryNode;
                if (x.Operator == "AND")
                {
                    return GetItems(x.LeftChild).Intersect(GetItems(x.RightChild));
                }
                else if (x.Operator == "OR")
                {
                    return GetItems(x.LeftChild).Concat(GetItems(x.RightChild));
                }
            }
            else if (node is UnaryNode)
            {
                var x = node as UnaryNode;
                if (x.Operator == "NOT")
                {
                    return GetAll().Except(GetItems(x.Child));
                }
            }
            throw new NotSupportedException();
        }
    }
