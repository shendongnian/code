       private void tvwACH_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string node = string.Empty;
            if (tvwACH.SelectedNode.Parent != null)
            {
                 node = tvwACH.SelectedNode.Text.ToString();
                if (node == "FileHeader")
                {
                    int tag = Convert.ToInt16(tvwACH.SelectedNode.Tag.ToString());
                    this.dataGridView1.Rows[0].Tag = tag;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        int rowId = (int)row.Tag;
                        if (rowId == tag)
                        {
                            row.Selected = true;
                        }
                    }
                }
                string strSwitch = tvwACH.SelectedNode.Parent.Text;
                switch (strSwitch)
                {
                    case "ACH":
                        {
                            dataGridView1.Visible = true;
                            dataGridView1.Rows.Clear();
                            node = tvwACH.SelectedNode.Text;
                            StreamReader sr = new StreamReader(node);
                            while (sr.Peek() >= 0)
                            {
                                string line = sr.ReadLine();
                                dataGridView1.Rows.Add(rectype[line.Substring(0, 1)].ToString(), line);
                            }
                            sr.Close();
                        }
                        break;
                }
            }
        }
