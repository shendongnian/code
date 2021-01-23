    class TreeElement 
    {
     public TreeElement Parent {get;}
     public IEnumerable<TreeElement> Children{get;};
     public AddChild(TreeElement element }
     public bool IsRoot { return Parent == null; }
     public bool IsLeaf { return Children.Length == 0; }
     public bool IsBranch {return !IsRoot && !IsLeaf; }
    }
