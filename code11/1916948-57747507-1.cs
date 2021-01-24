A
    C
        AB
        AC
    D
B
    E
        F
and given the need to update all immediate siblings of the needle node and all parent nodes including their siblings, here's my code:
csharp
using System;
using System.Linq;
namespace Ns
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var nodes = new[]
            {
                new NodeData("A",
                    new NodeData("C",
                        new NodeData("AB"),
                        new NodeData("AC")),
                    new NodeData("D")),
                new NodeData("B",
                    new NodeData("E",
                        new NodeData("F")))
            };
            FindAndUpdateAscendingly(nodes, "AB", x => Console.WriteLine(x.Text));
        }
        private static void FindAndUpdateAscendingly(NodeData[] rootNodes, string dataToFind, Action<NodeData> callback)
        {
            bool FindAndAscend(NodeData[] nodes)
            {
                var needleIsFound = nodes.Any(x => x.Text == dataToFind || FindAndAscend(x.Children));
                if (needleIsFound)
                {
                    foreach (var nodeData in nodes)
                    {
                        callback(nodeData);
                    }
                }
                return needleIsFound;
            }
            FindAndAscend(rootNodes);
        }
    }
    internal class NodeData
    {
        public NodeData(string text, params NodeData[] children)
        {
            Text = text;
            Children = children ?? Array.Empty<NodeData>();
        }
        public string Text { get; }
        public NodeData[] Children { get; }
    }
}
The gist of it is in the `FindAndUpdateAscendingly` function. You pass an array of nodes to it, a string you want to find, and a function you want to call on every node you would like to update.
Currently, I'm passing a `Console.WriteLine` as a fake "update" function, just to illustrate the iteration order. Here's the node iteration order as printed:
AB
AC
C
D
A
B
Basically, it searches for the node with the text you specify, and then bubbles up and calls the `callback` on all parent nodes and their siblings. That's why you don't touch `E` and `F` nodes.
For real data and real usage, instead of passing `Console.WriteLine`, you would pass a function that actually did something to the NodeData. For example, like this:
FindAndUpdateAscendingly(nodes, "AB", node =>
{
    node.Text += " - processed";
    Console.WriteLine(node.Text);
});
