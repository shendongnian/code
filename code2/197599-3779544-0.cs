        if (tvwACH.HitTest(location).Node.Nodes.Count > 0 && tvwACH.SelectedNode.Parent == null )
            {
                foreach (TreeNode node in tvwACH.Nodes)
                {
                    node.Nodes.Clear();
                }
        }
