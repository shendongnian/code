    private void Form4_Load(object sender, EventArgs e)
            {
                Process[] prs = Process.GetProcesses();
                listView1.Items.Clear();
                foreach (Process proces in prs)
                {
                    if (!string.IsNullOrEmpty(proces.MainWindowTitle))
                    {
                        ListViewItem item = new ListViewItem();
                        item.Tag = proces.Id; //it will be used to kill this process
                        item.Text = proces.MainWindowTitle;
                        listView1.Items.Add(item);
                    }
                }
            }
