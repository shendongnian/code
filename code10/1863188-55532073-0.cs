    var rightNavList = new List<UIBarButtonItem>();
    var navigationItem = this.NavigationController.TopViewController.NavigationItem;
    for (var i = 0; i < Element.ToolbarItems.Count; i++)
    {
        var reorder = (Element.ToolbarItems.Count - 1);
        var ItemPriority = Element.ToolbarItems[reorder - i].Priority;
        UIBarButtonItem RightNavItems = navigationItem.RightBarButtonItems[i];
        if (RightNavItems.Title == null)
            continue;
                    
        if (RightNavItems.Title.ToLower() == "add")
        {
            rightNavList.Add(new UIBarButtonItem(UIBarButtonSystemItem.Add)
            {
                Action = RightNavItems.Action,
                Target = RightNavItems.Target
            });
        }
        else if (RightNavItems.Title.ToLower() == "edit")
        {
            rightNavList.Add(new UIBarButtonItem(UIBarButtonSystemItem.Edit)
            {
                Action = RightNavItems.Action,
                Target = RightNavItems.Target
            });
        }
        else
        {
            rightNavList.Add(RightNavItems);
        }
    }
    navigationItem.SetRightBarButtonItems(rightNavList.ToArray(), false);
