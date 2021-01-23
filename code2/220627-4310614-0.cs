    see below code 
    so this fuction returns a stack in which top most item will be root and last item will be the immediate parent of element.
    public static Stack<TreeViewItem> GetNodeParent(UIElement element)
        {
            
            Stack<TreeViewItem> tempNodePath = new Stack<TreeViewItem>();
            // Walk up the element tree to the nearest tree view item.
            TreeViewItem container = element as TreeViewItem;
          
            while ((container == null) && (element != null))
            {
               
                element = VisualTreeHelper.GetParent(element) as UIElement;
                container = element as TreeViewItem;
                tempNodePath.Push(container);
            }
            return tempNodePath ;
        }
