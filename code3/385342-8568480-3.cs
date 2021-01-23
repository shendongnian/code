    protected string GetSuitableClientId(MenuItemTemplateContainer container)
    {
      MenuItem item = (MenuItem)container.DataItem;
      return String.Format("menuItem-{0}-{1}", item.Depth, container.ItemIndex);
    }
