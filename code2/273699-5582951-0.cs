    List<string> optieListBox = new List<string>();
    
            private List<TreeViewItem> GetAllItemContainers(TreeViewItem itemsControl)
            {
                List<TreeViewItem> allItems = new List<TreeViewItem>();
                for (int i = 0; i < itemsControl.Items.Count; i++)
                {
                    // try to get the item Container  
                    TreeViewItem childItemContainer = itemsControl.ItemContainerGenerator.ContainerFromIndex(i) as TreeViewItem;
                    // the item container maybe null if it is still not generated from the runtime  
                    if (childItemContainer != null)
                    {
                        allItems.Add(childItemContainer);
                        List<TreeViewItem> childItems = GetAllItemContainers(childItemContainer);
                        foreach (TreeViewItem childItem in childItems)
                        {
                            CheckBox checkBoxTemp = childItem.Header as CheckBox;
    
                            if (checkBoxTemp != null)
                                optieListBox.Items.Add(checkBoxTemp.Content);
    
                            allItems.Add(childItem);
                        }
                    }
                }
                return allItems;
            }
    
            private void GetContainers()
            {
                // gets all nodes from the TreeView  
                List<TreeViewItem> allTreeContainers = GetAllItemContainers(this.objTreeView);
                // gets all nodes (recursively) for the first node  
                TreeViewItem firstNode = this.objTreeView.ItemContainerGenerator.ContainerFromIndex(0) as TreeViewItem;
                if (firstNode != null)
                {
                    List<TreeViewItem> firstNodeContainers = GetAllItemContainers(firstNode);
                }
            }
    
    
            
