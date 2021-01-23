    public IEnumerable<Box> AllBoxes()
    {
        foreach (var box in this)
        {
            for (int i=0; i<box.ChildrenCount; i++)
            {
                yield return box.GetChild(i);
            }
        }
    }
