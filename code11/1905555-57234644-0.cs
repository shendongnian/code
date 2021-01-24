    foreach (var line in orderedCsv)
            {
                // Split only the single line
                var lineItems = line.Split(',');
                var listView1 = new ListViewItem {Text = lineItems[0]};
                listView1.SubItems.Add(lineItems[1]);
                listView1.SubItems.Add(lineItems[2]);
                listView1.SubItems.Add(lineItems[3]);
                listView1.SubItems.Add(lineItems[4]);
                listView1.Items.Add(listView1);
            }
