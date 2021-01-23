    private void addline(object sender, RoutedEventArgs e)
            {
                var incentive = ((sender as Button).Tag as ATG.ClientSide.SupportingObjects.StaffIncentiveHelperObject);
                incentive.AddStaffIncentiveLine(new ATG.Serverside.staffincentiveline());
                TreeViewItem thisTreeViewItem = MainTree.ItemContainerGenerator.ContainerFromItem(incentive) as TreeViewItem;
                thisTreeViewItem.IsExpanded = true;
            }
    
            private void delLine(object sender, RoutedEventArgs e)
            {
                var line = ((sender as Button).Tag as ATG.ClientSide.SupportingObjects.StaffIncentiveLineHelperObject);
                ATG.ClientSide.SupportingObjects.StaffIncentiveHelperObject thisIncentive = line.Parent;
                
                thisIncentive.RemoveStaffIncentiveLine(line);
                TreeViewItem thisTreeViewItem = MainTree.ItemContainerGenerator.ContainerFromItem(thisIncentive) as TreeViewItem;
                if (thisIncentive.StaffIncentiveLines.Count == 0)
                {
    
                    thisTreeViewItem.IsExpanded = false;
                }
            }
