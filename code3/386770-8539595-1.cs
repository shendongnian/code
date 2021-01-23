    internal void ToString(Ancestor root)
    {
        Trace.WriteLine(root.Name);
        Trace.Indent();
        foreach(var child in root.Children)
        {
             if(child is Parent)
                 ToString(new Ancestor(){Name = child.Name, 
                                         Children = ((Parent)child).Children});
             else
                 Trace.WriteLine(child.Name);
        }
        Trace.Unindent();
    }
