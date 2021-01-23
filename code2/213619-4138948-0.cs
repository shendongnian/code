    public IEnumerable<HtmlNode> Traverse()
    {
    foreach (var node in _context)
    {
        Console.WriteLine(node.Name);
        if(!node.HasChildren) {
         yield return node;
        }
        else {
        foreach (var child in Children().Traverse())
            yield return child;
        }
        }
    }
    }
