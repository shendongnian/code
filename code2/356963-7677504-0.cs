    public IEnumerable<INode> Ancestors(Func<INode, bool> takeUntil)
    {
       var parent = this.Parent;
       while (parent != null)
       {
          yield return parent;
          if (takeUntil(parent))
          {
             break;
          }
          parent = parent.Parent;
       }
    }
    ...
    var ancestors = node.Ancestors(n => n.Id == 123);
