    public class Main
    {
        public Main()
        {
            string treeStr = "";
            string[] strArr = { "a.b.c.d.e.f.g", "b.c.d.e.f.g.h.x" };
            List<Node> nodes = new List<Node>();
            Node currentNode;
            foreach (var str in strArr)
            {
                string[] split = str.Split('.');
                currentNode = null;
                for (int i = 0; i < split.Length; i++)
                {
                    var newNode = new Node { Value = str };
                    if (currentNode != null)
                    {
                        currentNode.Child = newNode;
                    }
                    currentNode = newNode;
                }
            }
        }
    }
    public class Node
    {
        public string Value { get; set; }
        public Node Child { get; set; }
    }
