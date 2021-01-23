    public void loadFromForm(string strNode, bool bResult, string strStandardClsCode)
        {
            if (Append.oldbatchcontrol != strNode)
            {
                if (tvwACH.SelectedNode.Text == "FileHeader")
                {
                    tvwACH.SelectedNode.Nodes.Add(strNode);
                }
                if (tvwACH.SelectedNode.Text == "BatchHeader")
                {
                    TreeNode node = tvwACH.SelectedNode.Nodes.Add(strNode,strNode);// After this i have to add another node as a child to that added node and also if a node with particular name exists i would like to write the text with a count value appended
                    node.Nodes.Add(...);
                }
      }
    }
