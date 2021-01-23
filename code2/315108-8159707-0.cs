        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //we have to handle both the first and future edits
            if ((e.Label != null && e.Label.Contains("|") || (e.Label == null && e.Node.Text.Contains("|"))))
            {
                if (WantAutofix())
                {
                    e.CancelEdit = true;
                    if(e.Label != null)
                        e.Node.Text = e.Label.Replace('|', '_');
                    else
                        e.Node.Text = e.Node.Text.Replace('|', '_');
                }
                else
                {
                    //lets the treeview finish up its OnAfterLabelEdit method
                    treeView1.BeginInvoke(new MethodInvoker(delegate() { e.Node.BeginEdit(); }));
                }
            }
        }
        private bool WantAutofix()
        {
            return MessageBox.Show("You entered a |, you want me to AutoFix?", String.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
