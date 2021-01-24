for (var i = 0; i <= 5; i++)
{
    var parentNode = treeViewTamsha.Nodes.Add($"Node {i}");
    for (var j = 0; j < 4; j++)
    {
        var childNode = treeViewTamsha.Nodes[treeViewTamsha.Nodes.Count - 1].Nodes
            .Add($"Child node: {i}.{j}");
    }
//***************** Moved this block after the nested for loop *****************/
    if (i < 3)
    {
        parentNode.Expand();
    }
    else
    {
        parentNode.Collapse();
    }
}
