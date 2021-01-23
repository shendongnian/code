    public static void SetParentsRecursive(Item parent)
    {
        List<Item> done = new List<Item>();
        Stack<Item> pending = new Stack<Item>();
        pending.Push(parent);
        while(pending.Count > 0)
        {
            parent = pending.Pop();
            foreach(var child in parent.Items)
            {
                if(!done.Contains(child))
                {
                    child.Parent = parent;
                    done.Add(child);
                    pending.Push(child);
                }                
            }
        }
    }
