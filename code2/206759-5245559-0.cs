        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            richEditControl1.Text = GetChildNodesIntoText(e.Node);
        }
        string GetChildNodesIntoText(TreeListNode tln)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(tln.GetValue(0).ToString());
            foreach (TreeListNode n in tln.Nodes)
            {
                sb.AppendLine(GetChildNodesIntoText(n));
            }
            return sb.ToString();
        }
