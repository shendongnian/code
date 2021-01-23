    private void addline(object sender, RoutedEventArgs e)
            {
                var incentive = ((sender as Button).Tag as StaffIncentiveHelperObject);
                incentive.AddStaffIncentiveLine(new staffincentiveline());
                TreeViewItem thisTreeViewItem = MainTree.ItemContainerGenerator.ContainerFromItem(incentive) as TreeViewItem;
                thisTreeViewItem.IsExpanded = true;
            }
    
            private void delLine(object sender, RoutedEventArgs e)
            {
                var line = ((sender as Button).Tag as StaffIncentiveLineHelperObject);
                StaffIncentiveHelperObject thisIncentive = line.Parent;
                
                thisIncentive.RemoveStaffIncentiveLine(line);
                TreeViewItem thisTreeViewItem = MainTree.ItemContainerGenerator.ContainerFromItem(thisIncentive) as TreeViewItem;
                if (thisIncentive.StaffIncentiveLines.Count == 0)
                {
    
                    thisTreeViewItem.IsExpanded = false;
                }
            }
