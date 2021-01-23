        void fieldFilterTxtBx_TextChanged(object sender, EventArgs e)
        {
            //blocks repainting tree till all objects loaded
            this.fieldsTree.BeginUpdate();
            this.fieldsTree.Nodes.Clear();
            if (this.fieldFilterTxtBx.Text != string.Empty)
            {
                foreach (TreeNode _parentNode in _fieldsTreeCache.Nodes)
                {
                    foreach (TreeNode _childNode in _parentNode.Nodes)
                    {
                        if (_childNode.Text.StartsWith(this.fieldFilterTxtBx.Text))
                        {
                            this.fieldsTree.Nodes.Add((TreeNode)_childNode.Clone());
                        }
                    }
                }
            }
            else
            {
                foreach (TreeNode _node in this._fieldsTreeCache.Nodes)
                {
                    fieldsTree.Nodes.Add((TreeNode)_node.Clone());
                }
            }
            //enables redrawing tree after all objects have been added
            this.fieldsTree.EndUpdate();
        }
