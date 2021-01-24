C#
public class Node{
    public string Value;
    public List<Node> Descendants;
    public Node(string value) { Value = value; }
    public void Add(Node n) { Descendants.Add(n); }
}
var root = new Node("root");
var n1 = new Node("sub")
root.Add(n1);
You can have a generic tree declaring `Node<T>`
