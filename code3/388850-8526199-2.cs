    namespace MiniTreeLibrary
    {
        public class SimpleNode
        {
            private string _info;
            private SimpleNode _left;
            private SimpleNode _right;
            private SimpleNode _parent;
    
            public SimpleNode(Node parent, string info)
            {     
                this._info = info;
                this.Parent = parent;
            }
    
            public Node Parent { get; private set; }
        }
    }
