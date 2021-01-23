`
 public static bool SelectDropDownItem(this AutomationElement comboBoxElement, string item)
        {
            bool itemFound = false;
            AutomationElement elementList;
            CacheRequest cacheRequest = new CacheRequest();
            cacheRequest.Add(AutomationElement.NameProperty);
            cacheRequest.TreeScope = TreeScope.Element | TreeScope.Children;
            using (cacheRequest.Activate())
            {
                // Load the list element and cache the specified properties for its descendants.
                Condition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.List);
                elementList = comboBoxElement.FindFirst(TreeScope.Children, cond);
            }
            //Loop thru and find the actual ListItem
            foreach (AutomationElement child in elementList.CachedChildren)
                if (child.Cached.Name == item)
                {
                    SelectionItemPattern select = (SelectionItemPattern)child.GetCurrentPattern(SelectionItemPattern.Pattern);
                    select.Select();
                    itemFound = true;
                    break;
                }
            return itemFound;
        }
`
