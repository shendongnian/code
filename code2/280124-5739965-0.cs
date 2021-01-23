    protected string getCheckedNodes(TreeNodeCollection tnc)
        {
            StringBuilder sb = new StringBuilder();
            foreach (TreeNode tn in tnc)
            {
                if (tn.Checked)
                {
                    string res = tn.FullPath;
                    if (res.Length > 0)
                        sb.AppendLine(res);
                }
                string childRes = getCheckedNodes(tn.Nodes);
                if (childRes.Length > 0)
                    sb.AppendLine(childRes);
            }
            return sb.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(getCheckedNodes(treeView1.Nodes));
        }
