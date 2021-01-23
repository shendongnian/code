        //Uncomplicated, reliable method
        List<int> _valueList = new List<int>();
        private List<int> getCheckedNodes(TreeNodeCollection _parentNodeList)
        {
            foreach (TreeNode item in _parentNodeList)
            {
                if (item.Checked)
                {
                    _valueList.Add(Convert.ToInt32(item.Value));
                }
                if (item.ChildNodes.Count > 0)
                {
                    //.NET does not forget where it stayed.
                    getCheckedNodes(item.ChildNodes);
                }
            } 
            return _valueList;
        }
