    {
        MyNode n = new MyNode();
        MyContainer c = new MyContainer();
        c.AddChild(n);
        OtherNode o = new OtherNode();
        o.AddChild(o);
    }
    public abstract class Node
    {
        Container parent;
        Node nextNode;
        Node previousNode;
        public abstract class Container : Node
        {
            Node firstChild;
            Node lastChild;
            public void AddChild(Node n)
            {
                firstChild = n;
                n.parent = this;
            }
        }
    }                
    public class MyNode : Node
    {
    }
    public class MyContainer : MyNode.Container
    {
    }
    public class OtherNode : Node.Container
    {
    }
