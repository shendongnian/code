    private void button1_Click(object sender, EventArgs e)
            {
                foreach (ListViewItem list in listView1.CheckedItems)
                {
                    Process p = System.Diagnostics.Process.GetProcessById(Convert.ToInt32(list.Tag));
                    if (p != null)
                        p.Kill();
                }
        }
