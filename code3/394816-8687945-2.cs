        if (menuParentList[i].MenuRole1 == "parent")
        {
            menuName = menuParentList[i].menuName.ToString();
            var newItem = new MenuItem();
            newItem.Text = menuName;
            menuItemList.Add(newItem);                             
            parentPosition = menuItemList.Count-1;   // flaky
        }
        else if (menuParentList[i].MenuRole1 == "child")
        {
            var newItem = new MenuItem();
            newItem.Text = menuParentList[i].menuName;
            newItem.NavigateUrl = menuParentList[i].MenuLink;
            hoverItem.Add(newItem);                             
            //menuItemList[i].ChildItems.Add(hoverItem[i]);
            menuItemList[parentPosition].ChildItems.Add(newItem);  // I think
        }
