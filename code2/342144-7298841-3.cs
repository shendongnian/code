    List<HtmlGenericControl> blocks = new List<HtmlGenericControl>();
    GetAllBlocks(pnlContainer, blocks);
    foreach (HtmlGenericControl block in blocks)
    {
        block.InnerHtml = "changed by code behind, id is " + block.Id;
    }
