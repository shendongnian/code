        //select menu item with matching NavigateUrl property
        foreach (MenuItem ParentMenu in menu.Items)
        {
            if (ParentMenu.NavigateUrl.ToLower() == Page.AppRelativeVirtualPath.ToLower())
            {
                ParentMenu.Selected = true;
            }
            else
            {
                foreach (MenuItem childMenu in ParentMenu.ChildItems)
                {
                    if (childMenu.NavigateUrl.ToLower() == Page.AppRelativeVirtualPath.ToLower())
                    {
                        childMenu.Selected = true;
                    }
                }
            }
        }
