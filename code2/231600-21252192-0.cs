    private void MultiClientResultForm_Load(object sender, EventArgs e)
        {
            foreach (string token in Main.ClientListResults)
            {
                string[] ResultRecord = token.Split(new string[] { "," }, StringSplitOptions.None);
                if (ResultRecord[0] != "")
                {
                    ListViewItem row = new ListViewItem(ResultRecord[0]);
                    row.SubItems.Add(new ListViewItem.ListViewSubItem(row, ResultRecord[2]));
                    if (ResultRecord[3] == "true")
                    {
                        row.SubItems.Add(new ListViewItem.ListViewSubItem(row, "Success"));
                        row.SubItems[2].ForeColor = Color.ForestGreen;
                    }
                    else 
                    {
                        row.SubItems.Add(new ListViewItem.ListViewSubItem(row, "Fail"));
                        row.SubItems[2].ForeColor = Color.DarkRed;
                    }
                    row.SubItems.Add(new ListViewItem.ListViewSubItem(row, ResultRecord[3]));
                    row.SubItems.Add(new ListViewItem.ListViewSubItem(row, ResultRecord[1]));
                    listViewResults.Items.Add(row);
                }
            }
        }
