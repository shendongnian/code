        /// <summary>
        /// A recursive method to add all of the records to the specified collection of nodes
        /// </summary>
        /// <param name="cRecords"></param>
        /// <param name="cNodes"></param>
        private void AddNodesToTree(MyRecordCollection cRecords, TreeNodeCollection cNodes)
        {
            foreach (MyRecord oRecord in cRecords.Values)
            {
                TreeNode oNode = new TreeNode();
                oNode.Text = oRecord.Name;
                oNode.Tag = oRecord;
                cNodes.Add(oNode);
                // Now add the node's children if any
                if (oRecord.Children.Count != 0)
                {
                    AddNodesToTree(oRecord.Children, oNode.Nodes);
                }
            }
        }
