    class TextParser{
            private Node Parse(string src){
                var top = new Node(null);
    
                for (int i = 0; i < src.Length - 3; i++){
                    var first = src[i];
                    var second = src[i+1];
                    var third = src[i+2];
                    var fourth = src[i+3];
    
                    var firstLevelNode = top.AddChild(first);
                    var secondLevelNode = firstLevelNode.AddChild(second);
                    var thirdLevelNode = secondLevelNode.AddChild(third);
                    thirdLevelNode.AddChild(fourth);
                }
    
                return top;
            }
        }
    
        public class Node{
            private readonly Node _parent;
            private readonly Dictionary<char,Node> _children 
                             = new Dictionary<char, Node>();
            private int _count;
    
            public Node(Node parent){
                _parent = parent;
            }
    
            public Node AddChild(char value){
                if (!_children.ContainsKey(value))
                {
                    _children.Add(value, new Node(this));
                }
                var levelNode = _children[value];
                levelNode._count++;
                return levelNode;
            }
            public decimal Probability(string substring){
                var node = this;
                foreach (var c in substring){
                    if(!node.Contains(c))
                        return 0m;
                    node = node[c];
                }
                return ((decimal) node._count)/node._parent._children.Count;
            }
    
            public Node this[char value]{
                get { return _children[value]; }
            }
            private bool Contains(char c){
                return _children.ContainsKey(c);
            }
        }
