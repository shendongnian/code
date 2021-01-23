     public JsonResult RefreshGroups(Group currentGroup, int rootUserGroupId)
        {
            parentIds = new List<int> { rootUserGroupId };
            var groupsTree = new List<Group> { GetGroupHierarchy(currentGroup, rootUserGroupId) };
            var treeViewItem = new TreeViewItem();
            treeViewItem.BindTo(groupsTree, mappings =>
                                                {
                                                    mappings.For<Group>(binding => binding
                                                    .ItemDataBound((item, group) =>
                                                                        {
                                                                            item.Text = group.GroupName;
                                                                            item.Value = group.GroupID.ToString();
                                                                            item.LoadOnDemand = true;
                                                                        })
                                                    .Children(group => group.SubGroups));
                                                });
            return new JsonResult
                       {
                           Data = new
                                      {
                                          ExpandedNodes = parentIds,
                                          Nodes = treeViewItem.Items
                                      }
                       };
        }
