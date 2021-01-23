    public void SortChildren(List<Child> childList)
    {
        childList.Sort((child1, child2) =>
        {
            if (child1.Type == child2.Type)
            {
                 // Sort by name
                 return child1.Name.CompareTo(child2.Name);
            }
            else
            {
                // Sort the type. If this sorts in reverse, swap child1 and child2
                return child1.Type.CompareTo(child2.Type);
            }
    
        });
        // Sort children recursively
        foreach(var child in childList)
        {
            SortChildren(child.Children);
        }
    }
