    static void Main(string[] args) {
        //Declare the local variable first.
        Func<Node, int> fSum = null;
        //We are now able to reference the local variable from within the lambda.
        fSum = (node) =>
            node.Info + (node.Left == null ? 0 :
            fSum(node.Left)) + (node.Right == null ? 0 :
            fSum(node.Right));
        //tree of nodes
        var n = new Node {Info = 1, Left = new Node {Info = 1}};
        //print out sum
        Console.WriteLine(fSum(n));
        Console.ReadLine();
    }
