    public class Node
    {
        public string Name {get; private set;}
        public List<Node> Children {get;set;}
        public Node Parent {get; private set}
        public int ElementDepth
        {
            get{ return Parent == null ? 1 : Parent.Depth + 1; }
        }
        public Node(string name, Node parent)
        {
            this.Name = name;
            this.Children = new List<Node>();
            this.Parent = parent;
        }
                
        public Node(byte[] xml, ref int startAt)
        {
            if(this.Depth == 2)
            {
                Console.WriteLine("In Container named \"" + this.Name +"\"");
            }
            /*  in this function:
             *  Get the tag name and either (recursively) create its children
             *  or return if it closes this tag
             */
        }
    }
