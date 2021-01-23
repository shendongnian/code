    using System.ComponentModel;
    /// <summary>
    /// Collection of SednaTreeViewItems used to populate the SednaTreeView.
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IEnumerable<SednaTreeViewItem> TreeNodes
    {
        get { return treeNodes; }
        set 
        {
            ultraTree.Nodes.Clear();
            treeNodes = value;
            foreach (var item in treeNodes)
            {
                UltraTreeNode node = new UltraTreeNode(item.ValueMember, item.DisplayMember);
                ultraTree.Nodes.Add(node);
            }
        }
    }
