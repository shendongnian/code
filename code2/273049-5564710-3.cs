    public IEnumerable<PageNode> GetChildNodes(IEnumerable<ContextItem> children)
    {
        return from c in children
               select new PageNode()
               {
                   Name = c.Fields["page name"],
                   URI = Sitecore.Links.LinkManager.GetItemUrl(c),
                   Children = c.Children.Any() ? GetChildNodes(c.Children) : null
               };
    }
    
    public PageNode LoadNode(ContextItem item)
    {
        return new PageNode()
               {
                   Name = item.Fields["page name"],
                   URI = Sitecore.Links.LinkManager.GetItemUrl(item),
                   Children = item.Children.Any() ? GetChildNodes(item.Children) : null
               };
    }
