    List<DotNetNuke.Entities.Tabs.TabInfo> tabs = TabController.GetTabsByParent(-1, 0).FindAll(
             delegate(DotNetNuke.Entities.Tabs.TabInfo tab)
             {
                 return tab.IsVisible;
             }
            );
