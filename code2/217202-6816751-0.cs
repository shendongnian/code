            foreach (TreeNode parent in TreeView1.Nodes)
            {
                foreach (TreeNode child in parent.ChildNodes)
                {
                    for (int j = 0; j < dt.Tables[0].Rows.Count; j++)
                    {
                        if (child.Value.Trim() == dt.Tables[0].Rows[j]["ClientId"].ToString().Trim())
                        {
                            child.Checked = true;
                            parent.Checked = true;
                            break;
                        }
                    }
                }
            }
