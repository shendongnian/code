    void GetAllBlocks(Control container, List<HtmlGenericControl> blocks)
    {
        foreach(var ctr in container.Controls.Cast<Control>)
        {
            if (ctr.Name.StartsWith("block") && ctr is HtmlGenericControl)
                blocks.Add(ctr);
            if (ctr.Controls.Count > 0)
                GetAllBlocks(ctr, blocks);
        }
    }
