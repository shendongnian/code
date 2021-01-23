    protected AutomationElement GetItem(AutomationElement element, string item)
        {
            AutomationElement elementList;
            CacheRequest cacheRequest = new CacheRequest();
            cacheRequest.Add(AutomationElement.NameProperty);
            cacheRequest.TreeScope = TreeScope.Element | TreeScope.Children;
            elementList = element.GetUpdatedCache(cacheRequest);
            foreach (AutomationElement child in elementList.CachedChildren)
                if (child.Cached.Name == item)
                    return child;
            return null;
        }
