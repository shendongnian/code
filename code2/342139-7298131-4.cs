    void IterAllBlocks(Control container, Action<Control> workWithBlock)
    {
        foreach(var ctr in container.Controls.Cast<Control>)
        {
           if (ctr.Name.StartsWith("block")
              workWithBlock(ctr);
           if (ctr.Controls.Count > 0) IterAllBlocks(ctr, workWithBlock);
        }
    }
